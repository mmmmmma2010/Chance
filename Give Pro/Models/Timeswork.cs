using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class Timeswork
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "مواعيد العمل")]
        public string TimesworkName { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }

        public virtual ICollection<PublisherProfile> PublisherProfiles { get; set; }


    }
}