using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationForum.Models
{
    public static class UserService
    {
        public static Forum forum = new Forum();
        public static User GetUserByLogPas(String login, String pass)
        {
            if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(pass))
            {
                return null;
            }
            String pass_hash = Utils.Utils.GetSHA_256(pass);
            var query =
                from
                u in forum.users
                where
                u.Nickname.Equals(login) && u.PassHash.Equals(pass_hash)
                select u;
            foreach(User u in query)
            {
                return u;
            }
            return null;
            
        }

        public static User GetUserByID(int id)
        {
            return forum.users.Find(id);
        }

    }


}
