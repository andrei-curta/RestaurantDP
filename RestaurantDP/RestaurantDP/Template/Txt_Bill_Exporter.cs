using System;
using System.Collections.Generic;
using System.Text;
using RestaurantDP.Factory;

namespace RestaurantDP.Template
{
    class Txt_Bill_Exporter : DataExporter
    {
        public Txt_Bill_Exporter()
        {
            _extension = "txt";
        }

        public override void ExportData()
        {
            Console.WriteLine("Exporting the data to a txt file.");
            Console.WriteLine($"{_fullPath}.{_extension}");
            System.IO.StreamWriter file = new System.IO.StreamWriter($"{_fullPath}.{_extension}");
            file.WriteLine(_data);

            file.Close();
        }
    }
}
