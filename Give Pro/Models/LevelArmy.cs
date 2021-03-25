using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class LevelArmy
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = " الموقف من التجنيد")]
        public string LevelArmyName { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }
        public virtual ICollection<ResearcherProfile> ResearcherProfiles { get; set; }

    }
}