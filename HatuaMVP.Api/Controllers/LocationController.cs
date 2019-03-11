using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gps.Api.Model;
using Gps.Api.Service;
using Microsoft.AspNetCore.Authorization;
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

        public LocationController(IHubContext<LocationHub, ILocationHubService> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public string Post([FromBody]Coordinates coordinates)
        {
            string retMessage = string.Empty;

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

        // Command to stop arduino
        // will implement later
        //[HttpPost]
        //public string Command([FromBody]string command)
        //{
        //    string retMessage = string.Empty;

        //    try
        //    {
        //        retMessage = "Success";
        //    }
        //    catch (Exception e)
        //    {
        //        retMessage = e.ToString();
        //    }

        //    return retMessage;
        //}

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}