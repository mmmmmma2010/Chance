using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class CompanyActivity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "نشاط الشركه")]
        public string CompanyActivityName { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }

        public virtual ICollection<PublisherProfile> PublisherProfiles { get; set; }

        public virtual ICollection<ResearcherProfile> ResearcherProfiles { get; set; }


    }
}