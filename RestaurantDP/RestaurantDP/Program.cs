using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using RestaurantDP.Factory;

namespace RestaurantDP
{
    class Program
    {
        static void Main(string[] args)
        {
            //User u = new User();

            //u.Name = "Ben";
            //u.Password = "123456789";
            //u.OfferType = Strategy.EOfferType.Student;

            UserRepository repository = new UserRepository(new MyContext());
            //repository.Insert(u);

            var client = repository.GetByID(5);


            var waiter = new Waiter();

            waiter.GetUserOption(client);

            //waiter.OrderBurger(Constants.ClassicBurgerName, Constants.ClassicBurgerPrice, EBurgerType.Classic);
            //waiter.OrderBurger(Constants.DeluxeBurgerName, Constants.DeluxeBurgerPrice, EBurgerType.Deluxe);
            //waiter.OrderBurger(Constants.ClassicBurgerName, Constants.ClassicBurgerPrice, EBurgerType.Classic);
            //waiter.OrderBurger(Constants.ClassicBurgerName, Constants.ClassicBurgerPrice, EBurgerType.Classic,
            //    EExtraIngredients.DRINK);

            //Console.WriteLine("\nOrdered burgers:");
            //waiter.DisplayBurgers();

            //waiter.SellBurger(1);
            //Console.WriteLine("\nAfter selling first burger.");
            //waiter.DisplayBurgers();
        }

    }
}