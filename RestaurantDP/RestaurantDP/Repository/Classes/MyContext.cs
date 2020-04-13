using Microsoft.EntityFrameworkCore;
using Repository;

namespace Repository
{
    public class MyContext : DbContext
    {
        //public MyContext(DbContextOptions<MyContext> options) : base(options)
        //{

        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //comentati si puneti al vostru
                optionsBuilder.UseMySql("server=localhost;database=restaurant;uid=root;pwd=123456789;");


                //optionsBuilder.UseMySql("Data Source=localhost:3306;Initial Catalog=restaurant;Username=root;Password=123456789");
                //optionsBuilder.UseMySql("server=localhost:3306;user=root;database=restaurant;password=123456789");
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-L0ATNCN\\SQLEXPRESS;Initial Catalog=designpatterns;Integrated Security=True");
                //optionsBuilder.UseSqlServer("Server=tcp:ctiserver.database.windows.net,1433;Initial Catalog=RestaurantDP;Persist Security Info=False;User ID=andrei;Password=ParolaRestaurant1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }


        public virtual DbSet<User> Users { get; set; }
    }
}
