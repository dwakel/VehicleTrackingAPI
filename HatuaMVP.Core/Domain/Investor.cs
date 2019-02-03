using HatuaMVP.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HatuaMVP.Core.Domain
{
    [Table("Investor")]
    public class Investor : EntityBase
    {
        [NotMapped]
        public string EncodedId => IDService.Encode("inv", Id);

        [Required]
        public int UserId { get; set; }

        [Required]
        public ApprovalStateValue AccountState { get; set; }
    }
}