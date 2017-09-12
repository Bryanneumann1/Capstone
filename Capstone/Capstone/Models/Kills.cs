using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Kills
    {
        public int ID { get; set; }
        [Required]
        public Stand Stand { get; set; }
        public int StandID { get; set; }
        public IEnumerable<Stand> Stands { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
    }
}