using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSSimApp.DAL.Models;

namespace CSSimApp.DAL.Repositories
{
    public class UserRepository : Repository<User>
    {
        public User Get(string userName, string password)
        {
            return _context.Set<User>().FirstOrDefault(a => a.UserName == userName && a.Password == password);
        }
    }
}
