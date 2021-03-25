using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class WorkHours
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "ساعات العمل")]
        public string WorkHoursName { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }

    }
}