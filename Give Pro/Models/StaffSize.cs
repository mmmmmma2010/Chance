using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class StaffSize
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "حجم الشركه")]
        public string StaffSizeName { get; set; }

        public virtual ICollection<PublisherProfile> PublisherProfiles { get; set; }

    }
}