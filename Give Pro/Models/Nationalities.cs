using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class Nationalities
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = " الجنسيه")]
        public string NationalitiesName { get; set; }
        public virtual ICollection<ResearcherProfile> ResearcherProfiles { get; set; }

    }
}