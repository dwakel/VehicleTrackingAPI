using HatuaMVP.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HatuaMVP.Core.Domain
{
    [Table("Company")]
    public class Company : EntityBase
    {
        [NotMapped]
        public string EncodedId => IDService.Encode("comp", Id);

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public ApprovalStateValue AccountState { get; set; }
    }
}