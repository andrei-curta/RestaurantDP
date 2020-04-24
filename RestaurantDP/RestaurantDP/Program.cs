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