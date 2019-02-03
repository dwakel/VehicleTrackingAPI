using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HatuaMVP.Core.Domain
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}