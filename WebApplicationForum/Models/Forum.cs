using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebApplicationForum.Models
{
    public class Forum :DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Theme> themes { get; set; }
        public Forum(): base("forumBd") { }
    }
}
