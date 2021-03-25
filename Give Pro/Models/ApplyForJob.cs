using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Give_Pro.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime ApplyDate { get; set; }

        public int JobsId { get; set; }

        public string UserId { get; set; }
        public int Rate { get; set; }

        public string CV { get; set; }


        public virtual Jobs Jobs { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}