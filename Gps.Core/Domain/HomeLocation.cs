using Gps.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Gps.Core.Domain
{
    [Table("HomeLocation")]
    public class HomeLocation : EntityBase
    {
        [NotMapped]
        public string EncodedId => IDService.Encode("homloc", Id);

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Required]
        public double Distance { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}