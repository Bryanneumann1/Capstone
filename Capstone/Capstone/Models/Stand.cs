using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Stand
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Stand Name")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}