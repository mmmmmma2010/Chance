using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Give_Pro.Models
{
    public class Governorates
    {
        public int Id { get; set; }

        [Required]
        [DisplayName(" المحافظه")]
        public string GovernoratesName { get; set; }

        [Required]
        [DisplayName(" الدوله")]
        public int CountriesID { get; set; }
        public virtual Countries Countries { get; set; }

        public virtual ICollection<Cities> Citiess { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }

        public virtual ICollection<PublisherProfile> PublisherProfiles { get; set; }
        public virtual ICollection<ResearcherProfile> ResearcherProfiles { get; set; }


    }
}