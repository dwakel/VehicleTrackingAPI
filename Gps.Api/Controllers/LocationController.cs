using System;
using System.Collections.Generic;
using System.Linq;
using Gps.Api.Model;
using Gps.Api.Service;
using Gps.Core.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
        private double distance;

        public LocationController(
            IHubContext<LocationHub, ILocationHubService> hubContext,
            GpsContext db)
        {
            _hubContext = hubContext;
            _db = db;
            this.SetDistance();
        }

        private void SetDistance() => this.distance = _db.HomeLocations.SingleOrDefault().Distance;

        [HttpPost]
        public string Post([FromBody]Coordinates coordinates)
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

            try
            {
                _hubContext.Clients.All.PinpointLocation(coordinates.Latitude, coordinates.Longitude);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return retMessage;
        }

        [HttpPut]
        public string Edit([FromForm] Coordinates coordinates, [FromForm] double Distance)
        {
            _db.HomeLocations.Update(
                new Core.Domain.HomeLocation
                {
                    Id = 1,
                    Latitude = coordinates.Latitude,
                    Longitude = coordinates.Longitude,
                    Distance = Distance
                });
            return "Complete";
        }

        [HttpPost]
        public ICollection<Coordinates> History([FromBody] DateTimeOffset start, [FromBody] DateTimeOffset end)
        {
            var result = _db.Locations
                .Where(date => date.CreatedAt >= start && date.CreatedAt <= end)
                .Select(coordinates => new Coordinates { Latitude = coordinates.Latitude, Longitude = coordinates.Longitude }).ToList();

            return result;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Hello", "World" };
        }
    }
}