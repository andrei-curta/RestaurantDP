using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using RestaurantDP.Template;

namespace RestaurantDP
{
    class Program
    {
        static void Main(string[] args)
        {
            DataExporter exporter = null;

            // Lets export the data to Excel file
            exporter = new Txt_Bill_Exporter();
            exporter.ExportFormatedData();

            Console.WriteLine();

            // Lets export the data to PDF file
            exporter = new PDF_Bill_Exporter();
            exporter.ExportFormatedData();

            User u = new User();

            u.Name = "21";
            u.Password = "12345678";


            UserRepository repository = new UserRepository(new MyContext());
            repository.Insert(u);

            var a =repository.GetAll();
            foreach(var x in a)
            {
                System.Console.WriteLine(x.ToString());
            }

            //var waiter = new Waiter();

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