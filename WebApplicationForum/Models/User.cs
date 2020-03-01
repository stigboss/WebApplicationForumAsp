using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationForum.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string RealName { get; set; }
        public string PassHash { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}