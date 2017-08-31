using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class SuccessfulHunts
    {
        public int ID { get; set; }

        public Stand Stand { get; set; }
        public int StandID { get; set; }
        public IEnumerable<Stand>Stands { get; set; }

        public string Wind { get; set; }

        [Display(Name = "Fehrenheit Temperature")]
        public int Temperature { get; set; }

        public Time Time { get; set; }
        [Display(Name = "AM / PM")]
        public string AMPM { get; set; }
        public IEnumerable<Time>Times { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Animal Type")]
        public string AnimalType { get; set; }

        [Display(Name = "Number of animals seen")]
        public int NumberOfAnimals { get; set; }

        [Display(Name = "Weather Conditions")]
        public string WeatherConditions { get; set; }


    }
}