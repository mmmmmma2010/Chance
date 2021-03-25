using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Give_Pro.Models
{
    public class JobsViewModel
    {
        public string JobName { get; set; }

        public IEnumerable<ApplyForJob> Items { get; set; }
    }
}