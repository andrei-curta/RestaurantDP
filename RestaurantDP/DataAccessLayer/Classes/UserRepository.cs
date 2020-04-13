
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MyContext dbContext)
        : base(dbContext)
        {

        }
    }
}
