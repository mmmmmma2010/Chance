using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class MonthlySalary
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "الراتب الأساسي")]
        public string MonthlySalaryName { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }

    }
}