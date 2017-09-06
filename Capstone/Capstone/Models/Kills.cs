using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Kills
    {
        public int ID { get; set; }

        public Stand Stand { get; set; }
        public int StandID { get; set; }
        public IEnumerable<Stand> Stands { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}