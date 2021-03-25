using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class AdvantagesWork
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "مميزات العمل")]
        public string AdvantagesWorkName { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }

    }
}