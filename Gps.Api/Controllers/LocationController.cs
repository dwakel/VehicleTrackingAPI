using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gps.Api.Model;
using Gps.Api.Service;
using Gps.Core.EF;
using Gps.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Gps.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private IHubContext<LocationHub, ILocationHubService> _hubContext;
        public GpsContext _db;
        public SendGridClient _client;
        private double distance;

        public LocationController(
            IHubContext<LocationHub, ILocationHubService> hubContext,
            SendGridClient client,
            GpsContext db)
        {
            _hubContext = hubContext;
            _client = client;
            _db = db;
            this.SetDistance();
        }

        private void SetDistance() => this.distance = _db.HomeLocations.SingleOrDefault().Distance;

        [HttpPost]
        public async Task<string> Post([FromBody]Coordinates coordinates)
        {
            string retMessage = string.Empty;
            _db.Locations.Add(
                new Core.Domain.Location
                {
                    Latitude = coordinates.Latitude,
                    Longitude = coordinates.Longitude,
                    Distance = this.distance,
                    UserId = 0,
                    CreatedAt = DateTimeOffset.Now
                });
            _db.SaveChanges();
            //Method to check the voilation
            string text = DistanceService.CalculateDistanceVoilation(
                this.distance,
                 Convert.ToDouble(_db.HomeLocations.SingleOrDefault().Latitude),
                 Convert.ToDouble(_db.HomeLocations.SingleOrDefault().Longitude),
                 Convert.ToDouble(coordinates.Latitude),
                 Convert.ToDouble(coordinates.Longitude));

            //Check the voilation
            // If it returns a null it means that the distance was voilated
            if (!string.IsNullOrEmpty(text))
            {
                //If th distance was voilated, sends and email to client here
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("no-reply@example.com", "CAR"),
                    Subject = "Car Alert",
                    PlainTextContent = text,
                    HtmlContent = "<strong>" + text + "</strong>"
                };

                msg.AddTo(new EmailAddress(_db.Users.SingleOrDefault().Email, (_db.Users.SingleOrDefault().FirstName)));
                var response = await _client.SendEmailAsync(msg);
            }

            try
            {
                //Send the actual coordinates to the web client using signalR
                await _hubContext.Clients.All.PinpointLocation(coordinates.Latitude, coordinates.Longitude);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return retMessage;
        }

        //[HttpPut]
        //public string Edit([FromForm] Coordinates coordinates, [FromForm] double Distance)
        //{
        //    _db.HomeLocations.Update(
        //        new Core.Domain.HomeLocation
        //        {
        //            Id = 1,
        //            Latitude = coordinates.Latitude,
        //            Longitude = coordinates.Longitude,
        //            Distance = Distance
        //        });
        //    return "Complete";
        //}

        //[HttpPost]
        //public ICollection<Coordinates> History([FromBody] DateTimeOffset start)
        //{
        //    var result = _db.Locations
        //        .Where(date => date.CreatedAt >= start && date.CreatedAt <= end)
        //        .Select(coordinates => new Coordinates { Latitude = coordinates.Latitude, Longitude = coordinates.Longitude }).ToList();

        //    return result;
        //}

        // a simple get request just to check if the api is up and working
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Status:", "API is up and working" };
        }
    }
}