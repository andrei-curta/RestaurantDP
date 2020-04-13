using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        {
        }


        public virtual DbSet<User> Users { get; set; }
    }
}
