using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class EducationLevel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "المؤهل التعليمي")]
        public string EducationLevelName { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }
        public virtual ICollection<ResearcherProfile> ResearcherProfiles { get; set; }

    }
}