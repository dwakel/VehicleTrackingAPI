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
                new Admin { FirstName = "Admin", LastName = "Admin", Username = "admin", Email = "admin@hatua.com", PasswordHash = PasswordHash, PasswordSalt = PasswordSalt }
            };

            foreach (Admin a in admin)
                context.Admins.Add(a);

            await context.SaveChangesAsync();

            #endregion Admin

            #region Investor

            //Create a password hash and salt for each
            PasswordService.CreatePasswordHash("investor", out byte[] iPasswordHash, out byte[] iPasswordSalt);
            PasswordService.CreatePasswordHash("investor1", out byte[] i1PasswordHash, out byte[] i1PasswordSalt);
            var investor = new Investor[]
            {
                new Investor { FirstName = "Samuel", LastName = "Kwasi", Username = "investor", Email = "investor@hatua.com", PasswordHash = iPasswordHash, PasswordSalt = iPasswordSalt, AccountState = ApprovalStateValue.Pending },
                new Investor { FirstName = "Andy", LastName = "Father", Username = "investor1", Email = "investor1@hatua.com", PasswordHash = i1PasswordHash, PasswordSalt = i1PasswordSalt, AccountState = ApprovalStateValue.Approved }
            };

            foreach (Investor i in investor)
                context.Investors.Add(i);

            await context.SaveChangesAsync();

            #endregion Investor

            #region ServiceProvider

            //Create a password hash and salt for each
            PasswordService.CreatePasswordHash("service", out byte[] sPasswordHash, out byte[] sPasswordSalt);
            PasswordService.CreatePasswordHash("service1", out byte[] s1PasswordHash, out byte[] s1PasswordSalt);
            var service = new ServiceProvider[]
            {
                new ServiceProvider { FirstName = "Mary", LastName = "Odai", Username = "service", Email = "service@hatua.com", PasswordHash = sPasswordHash, PasswordSalt = sPasswordSalt, AccountState = ApprovalStateValue.Pending },
                new ServiceProvider { FirstName = "Charlayne", LastName = "Kanlisi", Username = "service1", Email = "service1@hatua.com", PasswordHash = s1PasswordHash, PasswordSalt = s1PasswordSalt, AccountState = ApprovalStateValue.Approved }
            };

            foreach (ServiceProvider s in service)
                context.ServiceProviders.Add(s);

            await context.SaveChangesAsync();

            #endregion ServiceProvider

            #region Company

            //Create a password hash and salt for each
            PasswordService.CreatePasswordHash("company", out byte[] cPasswordHash, out byte[] cPasswordSalt);
            PasswordService.CreatePasswordHash("company1", out byte[] c1PasswordHash, out byte[] c1PasswordSalt);
            var company = new Company[]
            {
                new Company { FirstName = "Waheed", LastName = "Daoda", Username = "company", Email = "company@hatua.com", PasswordHash = cPasswordHash, PasswordSalt = cPasswordSalt, AccountState = ApprovalStateValue.Pending },
                new Company { FirstName = "Clinton", LastName = "Mbah", Username = "company1", Email = "company1@hatua.com", PasswordHash = c1PasswordHash, PasswordSalt = c1PasswordSalt, AccountState = ApprovalStateValue.Approved }
            };

            foreach (Company c in company)
                context.Companies.Add(c);

            await context.SaveChangesAsync();

            #endregion Company
        }
    }
}