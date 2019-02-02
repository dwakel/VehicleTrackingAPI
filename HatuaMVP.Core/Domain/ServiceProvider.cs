using HatuaMVP.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HatuaMVP.Core.Domain
{
    [Table("ServiceProvider")]
    public class ServiceProvider : EntityBase
    {
        [NotMapped]
        public string EncodedId => IDService.Encode("sp", Id);

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public UserRoleValue Role { get; set; } = UserRoleValue.ServiceProvider;

        public ApprovalStateValue AccountState { get; set; }
    }
}