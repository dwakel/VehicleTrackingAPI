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
                 new User { FirstName = "Gloria", LastName = "Sekyere", Username = "Gloria", Email = "gloria@gps.com", PasswordHash = PasswordHash, PasswordSalt = PasswordSalt, CreatedAt = DateTimeOffset.Now },
            };

            foreach (User iu in investorUser)
                context.Users.Add(iu);

            await context.SaveChangesAsync();

            int uID = context.Users.SingleOrDefault(user => user.Email == "gloria@gps.com").Id;

            var homeLocation = new HomeLocation[]
            {
                new HomeLocation {Id = 1, Latitude = "5.628928", Longitude = "-0.112121", Distance = 300,  UserId = uID, CreatedAt = DateTimeOffset.UtcNow }
            };
            double distance = context.HomeLocations.SingleOrDefault(user => user.Id == uID).Distance;

            var locations = new Location[]
            {
                 new Location { Latitude = "5.628928", Longitude = "-0.112121", Distance = distance, UserId = uID, CreatedAt = DateTimeOffset.UtcNow }
            };

            foreach (Location location in locations)
                context.Locations.Add(location);

            await context.SaveChangesAsync();

            //#endregion Admin

            //#region Investor

            ////Create a password hash and salt for each

            //int iuID1 = context.Users.SingleOrDefault(user => user.Email == "investor@Gps.com").Id;
            //int iuID2 = context.Users.SingleOrDefault(user => user.Email == "investor1@Gps.com").Id;

            //var investors = new Investor[]
            //{
            //    new Investor { UserId = iuID1, AccountState = ApprovalStateValue.Pending, CreatedAt = DateTimeOffset.Now },

            //    new Investor { UserId = iuID2, AccountState = ApprovalStateValue.Approved, CreatedAt = DateTimeOffset.Now }
            //};
            //foreach (Investor i in investors)
            //    context.Investors.Add(i);
            //await context.SaveChangesAsync();

            //#endregion Investor

            //#region ServiceProvider

            ////Create a password hash and salt for each
            //PasswordService.CreatePasswordHash("service", out byte[] sPasswordHash, out byte[] sPasswordSalt);
            //PasswordService.CreatePasswordHash("service1", out byte[] s1PasswordHash, out byte[] s1PasswordSalt);
            //var serviceUser = new User[]
            //{
            //    new User { FirstName = "Mary", LastName = "Odai", Username = "service", Email = "service@Gps.com", PasswordHash = sPasswordHash, PasswordSalt = sPasswordSalt, Role = UserRoleValue.ServiceProvider, CreatedAt = DateTimeOffset.Now },
            //    new User { FirstName = "Charlayne", LastName = "Kanlisi", Username = "service1", Email = "service1@Gps.com", PasswordHash = s1PasswordHash, PasswordSalt = s1PasswordSalt, Role = UserRoleValue.ServiceProvider, CreatedAt = DateTimeOffset.Now }
            //};

            //foreach (User su in serviceUser)
            //    context.Users.Add(su);

            //await context.SaveChangesAsync();

            //int suID1 = context.Users.SingleOrDefault(user => user.Email == "service@Gps.com").Id;
            //int suID2 = context.Users.SingleOrDefault(user => user.Email == "service1@Gps.com").Id;

            //var service = new ServiceProvider[]
            //{
            //    new ServiceProvider { UserId = suID1, AccountState = ApprovalStateValue.Pending, CreatedAt = DateTimeOffset.Now },

            //    new ServiceProvider { UserId = suID2, AccountState = ApprovalStateValue.Approved, CreatedAt = DateTimeOffset.Now }
            //};
            //foreach (ServiceProvider s in service)
            //    context.ServiceProviders.Add(s);
            //await context.SaveChangesAsync();

            //#endregion ServiceProvider

            //#region Company

            ////Create a password hash and salt for each
            //PasswordService.CreatePasswordHash("company", out byte[] cPasswordHash, out byte[] cPasswordSalt);
            //PasswordService.CreatePasswordHash("company1", out byte[] c1PasswordHash, out byte[] c1PasswordSalt);
            //var companyUser = new User[]
            //{
            //    new User { FirstName = "Waheed", LastName = "Daoda", Username = "company", Email = "company@Gps.com", PasswordHash = cPasswordHash, PasswordSalt = cPasswordSalt, Role = UserRoleValue.Company, CreatedAt = DateTimeOffset.Now },
            //    new User { FirstName = "Clinton", LastName = "Mbah", Username = "company1", Email = "company1@Gps.com", PasswordHash = c1PasswordHash, PasswordSalt = c1PasswordSalt, Role = UserRoleValue.Company, CreatedAt = DateTimeOffset.Now }
            //};

            //foreach (User cu in companyUser)
            //    context.Users.Add(cu);

            //await context.SaveChangesAsync();

            //int cuID1 = context.Users.SingleOrDefault(user => user.Email == "company@Gps.com").Id;
            //int cuID2 = context.Users.SingleOrDefault(user => user.Email == "company1@Gps.com").Id;

            //var company = new Company[]
            //{
            //    new Company { UserId = suID1, AccountState = ApprovalStateValue.Pending, CompanyName = "CompanyName1", CreatedAt = DateTimeOffset.Now },

            //    new Company { UserId = suID2, AccountState = ApprovalStateValue.Approved, CompanyName = "CompanyName2", CreatedAt = DateTimeOffset.Now }
            //};
            //foreach (Company c in company)
            //    context.Companies.Add(c);
            //await context.SaveChangesAsync();

            //#endregion Company
        }
    }
}