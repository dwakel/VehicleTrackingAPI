using HatuaMVP.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HatuaMVP.Core.Domain
{
    [Table("User")]
    public class User : EntityBase
    {
        [NotMapped]
        public string EncodedId => IDService.Encode("user", Id);

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public UserRoleValue Role { get; set; }
    }
}