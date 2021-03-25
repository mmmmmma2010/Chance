using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Give_Pro.Models
{
    public class Jobs
    {
            public int Id { get; set; }

            [Required]
            [DisplayName("أسم الوظيفه")]
            public string JobName { get; set; }

            [Required]
            [DisplayName("نوع الوظيفه")]
            public int CategoryID { get; set; }
            public virtual Category Category { get; set; }

            [Required]
            [DisplayName("أسم الشركه")]
            public string CompanyName { get; set; }

            [Required]
            [DisplayName("نشاط الشركه")]
            public int CompanyActivityID { get; set; }
            public virtual CompanyActivity CompanyActivity { get; set; }

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
            [DisplayName("تاريخ الأعلان")]
            public DateTime DatePublication { get; set; }

            [Required]
            [DisplayName("العماله المطلوبه")]
            public int RequiredWorkersID { get; set; }
            public virtual RequiredWorkers RequiredWorkers { get; set; }


            [Required]
            [DisplayName("سنوات الخبره")]
            public int YearsExperienceID { get; set; }
            public virtual YearsExperience YearsExperience { get; set; }


            [Required]
            [DisplayName("السن المطلوب")]
            public int AgeID { get; set; }
            public virtual Age Age { get; set; }

            [Required]
            [DisplayName("النوع المطلوب")]
            public int GenderID { get; set; }
            public virtual Gender Gender { get; set; }

            [Required]
            [DisplayName("رخصة القياده")]
            public int DrivingLicenseID { get; set; }
            public virtual DrivingLicense DrivingLicense { get; set; }


            [Required]
            [DisplayName("مستوي التعليم")]
            public int EducationLevelID { get; set; }
            public virtual EducationLevel EducationLevel { get; set; }


            [Required]
            [DisplayName("اللغه الأنجليزيه")]
            public int LevelEnglishID { get; set; }
            public virtual LevelEnglish LevelEnglishI { get; set; }


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
            [DisplayName("شروط أخري")]
            public string OtherTerms { get; set; }

            [Required]
            [DisplayName("الراتب الأساسي")]
            public int MonthlySalaryID { get; set; }
            public virtual MonthlySalary MonthlySalary { get; set; }


            [Required]
            [DisplayName("سعر الساعه الأضافيه")]
            public string WatchPrice { get; set; }


            [Required]
            [DisplayName("نوع الدوام")]
            public int AlwaysID { get; set; }
            public virtual Always Always { get; set; }



            [Required]
            [DisplayName("مواعيد العمل")]
            public int TimesworkID { get; set; }
            public virtual Timeswork Timeswork { get; set; }


            [Required]
            [DisplayName("ساعات العمل")]
            public int WorkHoursID { get; set; }
            public virtual WorkHours WorkHours { get; set; }


            [Required]
            [DisplayName(" الإجازات")]
            public int WeekendID { get; set; }
            public virtual Weekend Weekend { get; set; }

            [Required]
            [DisplayName("مميزات الوظيفه")]
            public int AdvantagesWorkID { get; set; }
            public virtual AdvantagesWork AdvantagesWork { get; set; }


            //[Required]
            [DisplayName("الصوره")]
            public string JobImage { get; set; }

            public string UserID { get; set; }
            public virtual ApplicationUser User { get; set; }



    }
}