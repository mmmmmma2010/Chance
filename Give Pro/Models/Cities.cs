using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Give_Pro.Models
{
    public class Cities
    {
        public int Id { get; set; }

        [Required]
        [DisplayName(" المدينه")]
        public string CitiesName { get; set; }

        [Required]
        [DisplayName(" المحافظه")]
        public int GovernoratesID { get; set; }
        public virtual Governorates Governorates { get; set; }

        public virtual ICollection<Jobs> Jobss { get; set; }

        public virtual ICollection<PublisherProfile> PublisherProfiles { get; set; }

        public virtual ICollection<ResearcherProfile> ResearcherProfiles { get; set; }

    }
}