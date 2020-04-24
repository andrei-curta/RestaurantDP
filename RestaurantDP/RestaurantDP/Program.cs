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

            Receptioner receptioner = new Receptioner();

            User client = receptioner.GreetClient();

            if (client != null)
            {
                var waiter = new Waiter();
                System.Console.WriteLine("<<Waiter arrives>>");
                waiter.GetUserOption(client);
            }
        }
    }
}