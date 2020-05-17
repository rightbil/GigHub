using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Genre
    {
        [Required]
        public byte Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }

    }
}