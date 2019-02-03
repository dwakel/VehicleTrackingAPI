﻿using HatuaMVP.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HatuaMVP.Core.Domain
{
    [Table("Company")]
    public class Company : EntityBase
    {
        [NotMapped]
        public string EncodedId => IDService.Encode("comp", Id);

        [Required]
        public int UserId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public ApprovalStateValue AccountState { get; set; }
    }
}