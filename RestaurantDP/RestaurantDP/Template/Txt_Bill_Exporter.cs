using System;
using System.Collections.Generic;
using System.Text;
using RestaurantDP.Factory;

namespace RestaurantDP.Template
{
    class Txt_Bill_Exporter : DataExporter
    {
        public override void ExportData()
        {
              Console.WriteLine("Exporting the data to a PDF file.");
            string lines = "First line.\r\nSecond line.\r\nThird line.";

            //cum adaug calea relativa?

            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\Faculty\\Design_Patterns\\Proiect_Hamburger\\RestaurantDP\\RestaurantDP\\RestaurantDP\\Template\\third" +
                ".txt");
            file.WriteLine(lines);

            file.Close();
        }
    }
}
