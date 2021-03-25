using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class LevelOffice
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = " مستوي مايكروسوفت أوفس")]
        public string LevelOfficeName { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }
        public virtual ICollection<ResearcherProfile> ResearcherProfiles { get; set; }

    }
}