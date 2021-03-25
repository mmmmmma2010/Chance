using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class Gender
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "النوع")]
        public string GenderName { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }

        public virtual ICollection<ResearcherProfile> ResearcherProfiles { get; set; }

    }
}