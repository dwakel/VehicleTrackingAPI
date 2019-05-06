using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Gps.Core.Domain;
using Gps.Core.Services;

namespace Gps.Core.EF
{
    public static class DbInitializer
    {
        public static async void Initialize(GpsContext context)
        {
            ////Delete a recreate database when application starts before running seeds
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            //#region Admin

            //PasswordService.CreatePasswordHash("Location", out byte[] PasswordHash, out byte[] PasswordSalt);
            PasswordService.CreatePasswordHash("gloria", out byte[] PasswordHash, out byte[] PasswordSalt);

            var investorUser = new User[]
            {
                 new User { FirstName = "Gloria", LastName = "Sekyere", Username = "Gloria", Email = "gloriasekyere15@gmail.com", PasswordHash = PasswordHash, PasswordSalt = PasswordSalt, CreatedAt = DateTimeOffset.Now },
            };

            foreach (User iu in investorUser)
                context.Users.Add(iu);

            await context.SaveChangesAsync();

            int uID = context.Users.SingleOrDefault(user => user.Email == "gloriasekyere15@gmail.com").Id;

            var homeLocations = new HomeLocation[]
            {
                new HomeLocation {Latitude = "5.759553", Longitude = "-0.220318", Distance = 300,  UserId = uID, CreatedAt = DateTimeOffset.UtcNow }
            };
            foreach (HomeLocation home in homeLocations)
                context.HomeLocations.Add(home);

            await context.SaveChangesAsync();
            double distance = context.HomeLocations.SingleOrDefault(user => user.Id == uID).Distance;

            var locations = new Location[]
            {
                 new Location { Latitude = "5.628928", Longitude = "-0.112121", Distance = distance, UserId = uID, CreatedAt = DateTimeOffset.UtcNow }
            };

            foreach (Location location in locations)
                context.Locations.Add(location);

            await context.SaveChangesAsync();
        }
    }
}