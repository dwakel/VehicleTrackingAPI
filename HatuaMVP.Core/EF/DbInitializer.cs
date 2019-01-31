using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HatuaMVP.Core.EF
{
    public static class DbInitializer
    {
        public static async void Initialize(HatuaContext context)
        {
            //Check if Db has data in already
            //if (context.Investors.Any() ||
            //    context.ServiceProviders.Any() ||
            //    context.Companies.Any() ||
            //    context.Admins.Any())
            //{
            //    return; //Db already has data, no need for dummy data
            //}
        }
    }
}