using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HatuaMVP.Core.Domain;
using HatuaMVP.Core.Services;

namespace HatuaMVP.Core.EF
{
    public static class DbInitializer
    {
        public static async void Initialize(HatuaContext context)
        {
            //Delete a recreate database when application starts before running seeds
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            #region Admin

            PasswordService.CreatePasswordHash("admin", out byte[] PasswordHash, out byte[] PasswordSalt);

            var admin = new Admin[]
            {
                new Admin { FirstName = "Admin", LastName = "Admin", Username = "admin", Email = "admin@hatua.com", PasswordHash = PasswordHash, PasswordSalt = PasswordSalt, Role = UserRoleValue.Admin }
            };

            foreach (Admin a in admin)
                context.Admins.Add(a);

            await context.SaveChangesAsync();

            #endregion Admin

            #region Investor

            //Create a password hash and salt for each
            PasswordService.CreatePasswordHash("investor", out byte[] iPasswordHash, out byte[] iPasswordSalt);
            PasswordService.CreatePasswordHash("investor1", out byte[] i1PasswordHash, out byte[] i1PasswordSalt);
            var investorUser = new User[]
            {
                new User { FirstName = "Samuel", LastName = "Kwasi", Username = "investor", Email = "investor@hatua.com", PasswordHash = iPasswordHash, PasswordSalt = iPasswordSalt, Role = UserRoleValue.Investor, CreatedAt = DateTimeOffset.Now },
                new User { FirstName = "Andy", LastName = "Father", Username = "investor1", Email = "investor1@hatua.com", PasswordHash = i1PasswordHash, PasswordSalt = i1PasswordSalt, Role = UserRoleValue.Investor, CreatedAt = DateTimeOffset.Now }
            };

            foreach (User iu in investorUser)
                context.Users.Add(iu);

            await context.SaveChangesAsync();

            int iuID1 = context.Users.SingleOrDefault(user => user.Email == "investor@hatua.com").Id;
            int iuID2 = context.Users.SingleOrDefault(user => user.Email == "investor1@hatua.com").Id;

            var ivestors = new Investor[]
            {
                new Investor { UserId = iuID1, AccountState = ApprovalStateValue.Pending },

                new Investor { UserId = iuID2, AccountState = ApprovalStateValue.Approved }
            };
            await context.SaveChangesAsync();

            #endregion Investor

            #region ServiceProvider

            //Create a password hash and salt for each
            PasswordService.CreatePasswordHash("service", out byte[] sPasswordHash, out byte[] sPasswordSalt);
            PasswordService.CreatePasswordHash("service1", out byte[] s1PasswordHash, out byte[] s1PasswordSalt);
            var serviceUser = new User[]
            {
                new User { FirstName = "Mary", LastName = "Odai", Username = "service", Email = "service@hatua.com", PasswordHash = sPasswordHash, PasswordSalt = sPasswordSalt, Role = UserRoleValue.ServiceProvider, CreatedAt = DateTimeOffset.Now },
                new User { FirstName = "Charlayne", LastName = "Kanlisi", Username = "service1", Email = "service1@hatua.com", PasswordHash = s1PasswordHash, PasswordSalt = s1PasswordSalt, Role = UserRoleValue.ServiceProvider, CreatedAt = DateTimeOffset.Now }
            };

            foreach (User su in serviceUser)
                context.Users.Add(su);

            await context.SaveChangesAsync();

            int suID1 = context.Users.SingleOrDefault(user => user.Email == "service@hatua.com").Id;
            int suID2 = context.Users.SingleOrDefault(user => user.Email == "service1@hatua.com").Id;

            var service = new ServiceProvider[]
            {
                new ServiceProvider { UserId = suID1, AccountState = ApprovalStateValue.Pending },

                new ServiceProvider { UserId = suID2, AccountState = ApprovalStateValue.Approved }
            };
            await context.SaveChangesAsync();

            #endregion ServiceProvider

            #region Company

            //Create a password hash and salt for each
            PasswordService.CreatePasswordHash("company", out byte[] cPasswordHash, out byte[] cPasswordSalt);
            PasswordService.CreatePasswordHash("company1", out byte[] c1PasswordHash, out byte[] c1PasswordSalt);
            var companyUser = new User[]
            {
                new User { FirstName = "Waheed", LastName = "Daoda", Username = "company", Email = "company@hatua.com", PasswordHash = cPasswordHash, PasswordSalt = cPasswordSalt, Role = UserRoleValue.Company, CreatedAt = DateTimeOffset.Now },
                new User { FirstName = "Clinton", LastName = "Mbah", Username = "company1", Email = "company1@hatua.com", PasswordHash = c1PasswordHash, PasswordSalt = c1PasswordSalt, Role = UserRoleValue.Company, CreatedAt = DateTimeOffset.Now }
            };

            foreach (User cu in companyUser)
                context.Users.Add(cu);

            await context.SaveChangesAsync();

            int cuID1 = context.Users.SingleOrDefault(user => user.Email == "company@hatua.com").Id;
            int cuID2 = context.Users.SingleOrDefault(user => user.Email == "company1@hatua.com").Id;

            var company = new Company[]
            {
                new Company { UserId = suID1, AccountState = ApprovalStateValue.Pending },

                new Company { UserId = suID2, AccountState = ApprovalStateValue.Approved }
            };
            await context.SaveChangesAsync();

            #endregion Company
        }
    }
}