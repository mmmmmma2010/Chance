using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class DrivingLicense
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "رخصة القياده ")]
        public string DrivingLicenseName { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }

        public virtual ICollection<ResearcherProfile> ResearcherProfiles { get; set; }

    }
}