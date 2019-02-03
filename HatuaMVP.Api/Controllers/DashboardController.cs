using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HatuaMVP.Core.EF;
using HatuaMVP.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HatuaMVP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private HatuaContext _context;

        public DashboardController(HatuaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Index(string Id)
        {
            var dId = IDService.Decode(Id);
            var user = _context.Users.SingleOrDefault(x => x.Id == dId);
            dynamic dashboard;
            switch (user.Role)
            {
                case Core.Domain.UserRoleValue.Investor:
                    dashboard = _context.Investors.SingleOrDefault(x => x.UserId == dId);
                    return Ok(new
                    {
                        dashboard.EncodedId,
                        dashboard.AccountState
                    });

                case Core.Domain.UserRoleValue.ServiceProvider:
                    dashboard = _context.ServiceProviders.SingleOrDefault(x => x.UserId == dId);
                    return Ok(new
                    {
                        dashboard.EncodedId,
                        dashboard.AccountState
                    });

                case Core.Domain.UserRoleValue.Company:
                    dashboard = _context.Companies.SingleOrDefault(x => x.UserId == dId);
                    return Ok(new
                    {
                        dashboard.EncodedId,
                        dashboard.AccountState
                    });

                default:
                    break;
            }
            return new string[] { "value1", "value2" };
        }
    }
}