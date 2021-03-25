using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Give_Pro.Models
{
    public class ResearcherProfile
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("الأسم بالكامل")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("الرقم القومي")]
        public string NumberCard { get; set; }

        [Required]
        [DisplayName("تاريخ الإنتهاء")]
        public string DateEnd { get; set; }

        [Required]
        [DisplayName("تاريخ الميلاد")]
        public string DateBirth { get; set; }

        [Required]
        [DisplayName("العمر")]
        public int AgeID { get; set; }
        public virtual Age Age { get; set; }

        [Required]
        [DisplayName("الجنسيه")]
        public int NationalitiesID { get; set; }
        public virtual Nationalities Nationalities { get; set; }

        [Required]
        [DisplayName("النوع")]
        public int GenderID { get; set; }
        public virtual Gender Gender { get; set; }

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
        [DisplayName("رخصة القياده")]
        public int DrivingLicenseID { get; set; }
        public virtual DrivingLicense DrivingLicense { get; set; }


        [Required]
        [DisplayName("المؤهل التعليمي")]
        public int EducationLevelID { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }


        [Required]
        [DisplayName("اللغه الأنجليزيه")]
        public int LevelEnglishID { get; set; }
        public virtual LevelEnglish LevelEnglish { get; set; }


        [Required]
        [DisplayName("الحاسب الآلي")]
        public int LevelComputerID { get; set; }
        public virtual LevelComputer LevelComputer { get; set; }

        [Required]
        [DisplayName("مايكروسوفت أوفيس")]
        public int LevelOfficeID { get; set; }
        public virtual LevelOffice LevelOffice { get; set; }


        [Required]
        [DisplayName("الموقف من التجنيد")]
        public int LevelArmyID { get; set; }
        public virtual LevelArmy LevelArmy { get; set; }


        [Required]
        [DisplayName("المجال الوظيفي")]
        public int CompanyActivityID { get; set; }
        public virtual CompanyActivity CompanyActivity { get; set; }



        [Required]
        [DisplayName("سنوات الخبره")]
        public int YearsExperienceID { get; set; }
        public virtual YearsExperience YearsExperience { get; set; }


        [DisplayName("السيره الذاتيه")]
        public string FileCV { get; set; }

        
        [DisplayName("كلمة المرور")]
        public string Password { get; set; }

        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}