using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Give_Pro.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [DisplayName("الأدوار")]
        public string Name { get; set; }

    }
}