using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gps.Core.Domain
{
    /// <summary>
    /// All table objects inherit from this
    /// and implement the properties here
    /// </summary>
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}