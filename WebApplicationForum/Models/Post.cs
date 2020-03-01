using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationForum.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int IdTheme { get; set; }
        public int IdUser { get; set; }
        public int IdCite { get; set; }             // нужно было int?
        public string Content { get; set; }
        public DateTime? Moment { get; set; }
    }
}
