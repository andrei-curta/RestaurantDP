
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MyContext dbContext)
        : base(dbContext)
        {

        }
    }
}
