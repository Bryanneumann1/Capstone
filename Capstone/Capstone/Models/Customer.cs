using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        public Stand Stand { get; set; }
        [Display(Name = "Stand Choice")]
        public int StandID { get; set; }
        public IEnumerable<Stand> Stands { get; set; }

        [Display(Name = "Choose Date of Hunt")]
        public DateTime Date { get; set; }

        [Display(Name = "Coupon Code")]
        public String Coupon { get; set; }

    }
}