using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Give_Pro.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "نوع الوظيفه")]
        public string CategoryName { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }

    }
}