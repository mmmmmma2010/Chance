using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class Always
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("نوع الدوام")]
        public string ContinuityName { get; set; }
        public virtual ICollection<Jobs> Jobss { get; set; }

    }
}