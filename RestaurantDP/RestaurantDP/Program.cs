using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using RestaurantDP.Bridge;
using RestaurantDP.Factory;
using RestaurantDP.Template;

namespace RestaurantDP
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationMode.Instance.DisplayOption = FileMessage.Instance;
            
            User u = new User();

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