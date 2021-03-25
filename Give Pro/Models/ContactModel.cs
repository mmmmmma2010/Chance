using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Give_Pro.Models
{
    public class ContactModel
    {
        [Required]
        [DisplayName("الأسم")]
        public string Name { get; set; }

        [Required]
        [DisplayName("البريد الألكتروني")]
        public string Email { get; set; }

        [Required]
        [DisplayName("موضوع الرساله")]
        public string Subject { get; set; }

        [Required]
        [DisplayName("محتوي الرساله")]
        public string Message { get; set; }


    }
}