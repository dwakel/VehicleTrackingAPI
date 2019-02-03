using HatuaMVP.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HatuaMVP.Core.Domain
{
    public class UserDto
    {
        public int EncodedId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}