using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Give_Pro.Models
{


    public class PublisherProfile
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("الأسم بالكامل")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("الرقم القومي")]
        public string NumberCard { get; set; }

        [Required]
        [DisplayName("تاريخ الإنتهاء الوظيفه")]
        public string DateEnd { get; set; }

        [Required]
        [DisplayName("تاريخ الميلاد")]
        public string DateBirth { get; set; }


        [Required]
        [DisplayName("رقم الهاتف")]
        public string NumberPhone { get; set; }

        [Required]
        [DisplayName(" الدوله")]
        public int CountriesID { get; set; }
        public virtual Countries Countries { get; set; }

        [Required]
        [DisplayName(" المحافظه")]
        public int GovernoratesID { get; set; }
        public virtual Governorates Governorates { get; set; }

        [Required]
        [DisplayName(" المدينه")]
        public int CitiesID { get; set; }
        public virtual Cities Cities { get; set; }

        [Required]
        [DisplayName("العنوان بالتفصيل")]
        public string AddressDetails { get; set; }


        [Required]
        [DisplayName("أسم الشركه")]
        public string CompanyName { get; set; }


        [Required]
        [DisplayName("نشاط الشركه")]
        public int CompanyActivityID { get; set; }
        public virtual CompanyActivity CompanyActivity { get; set; }

        [Required]
        [DisplayName("حجم الشركه")]
        public int StaffSizeID { get; set; }
        public virtual StaffSize StaffSize { get; set; }

        [Required]
        [DisplayName("رقم السجل التجاري")]
        public string ComRegistrationNo { get; set; }

        [DisplayName("الورق القانوني")]
        public string LegalPaper { get; set; }

        [Required]
        [DisplayName("البريد الألكتروني")]
        public string Email { get; set; }


        [Required]
        [Url]
        [DisplayName("الموقع الألكتروني")]
        public string WebSite { get; set; }


        [Required]
        [DisplayName("مواعيد العمل")]
        public int TimesworkID { get; set; }
        public virtual Timeswork Timeswork { get; set; }

        [Required]
        [DisplayName("الرقم الأرضي")]
        public string GroundNumber { get; set; }

        
        [DisplayName("كلمة المرور")]
        public string Password { get; set; }

        
        [DisplayName("لوجو الشركة")]
        public string CompLogo { get; set; }

        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }


    }
}