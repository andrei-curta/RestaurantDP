
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MyContext dbContext)
        : base(dbContext)
        {
           
        }

        public User GetByName(string name)
        {
           return _dbContext.Set<User>().FirstOrDefault(u => u.Name == name);
        }
    }
}
