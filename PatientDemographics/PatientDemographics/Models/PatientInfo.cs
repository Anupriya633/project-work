using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PatientDemographics.Models
{
    
    public class PatientInfo
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string ForeName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(140)]
        public string Surname { get; set; }
       // [RegularExpression("/^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/)]
        public string DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Home { get; set; }
        public string Work { get; set; }
        public string Mobile { get; set; }
        public TelephoneNumber TelephoneNumber{ get; set; }
    }

    public class TelephoneNumber
    {
        public string Home { get; set; }
        public string Work { get; set; }
        public string Mobile { get; set; }
    }

    public class Update
    {
        [Required]
        [MaxLength(140)]
        public string Status { get; set; }

        public DateTime Date { get; set; }
    }
}