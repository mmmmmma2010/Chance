using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Give_Pro.Models
{
    public class Currency
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "أسم العمله")]
        public string CurrencyName { get; set; }
    }
}