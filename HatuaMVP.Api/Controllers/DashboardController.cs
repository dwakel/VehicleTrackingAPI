using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HatuaMVP.Core.Domain;
using HatuaMVP.Core.EF;
using HatuaMVP.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HatuaMVP.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private HatuaContext _context;

        public DashboardController(HatuaContext context)
        {
            _context = context;
        }

        //[Authorize]
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "Dashboard", "Dashboard" };
        //}

        [Authorize]
        [Route("{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Index([FromRoute]string id)
        {
            var dId = IDService.Decode(id);
            var user = _context.Users.SingleOrDefault(x => x.Id == dId);
            dynamic dashboard;
            switch (user.Role)
            {
                case Core.Domain.UserRoleValue.Investor:
                    dashboard = _context.Investors.SingleOrDefault<Investor>(i => i.UserId == dId);
                    return Ok(new
                    {
                        dashboard.EncodedId,
                        dashboard.AccountState
                    });

                case Core.Domain.UserRoleValue.ServiceProvider:
                    dashboard = _context.ServiceProviders.SingleOrDefault<ServiceProvider>(x => x.UserId == dId);
                    return Ok(new
                    {
                        dashboard.EncodedId,
                        dashboard.AccountState,
                    });

                case Core.Domain.UserRoleValue.Company:
                    dashboard = _context.Companies.SingleOrDefault<Company>(x => x.UserId == dId);
                    return Ok(new
                    {
                        dashboard.EncodedId,
                        dashboard.AccountState,
                    });

                default:
                    break;
            }
            return new string[] { "value1", "value2" };
        }
    }
}