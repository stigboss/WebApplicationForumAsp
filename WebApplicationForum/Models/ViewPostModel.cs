using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationForum.Models
{
    public class ViewPostModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime? Moment { get; set; }
    }
}
