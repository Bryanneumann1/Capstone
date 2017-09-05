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
        public IEnumerable<Stand> Stands { get; set; }

        [Display(Name = "Wind Direction")]
        public string Wind { get; set; }

        [Display(Name = "Fehrenheit Temperature")]
        public int Temperature { get; set; }

        [Display(Name = "Date and time of Hunt")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Display(Name = "Animal Species Hunted")]
        public string AnimalType { get; set; }

        [Display(Name = "Number of animals seen")]
        public int NumberOfAnimals { get; set; }

        [Display(Name = "Weather Description")]
        public string WeatherConditions { get; set; }

        [Display(Name = "Descripition about your Successful Hunt")]
        public string Description { get; set; }

    }
}