using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class YearsExperience
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "سنوات الخبره")]
        public string YearsExperienceName { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }
        public virtual ICollection<ResearcherProfile> ResearcherProfiles { get; set; }

    }
}