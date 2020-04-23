using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP.Template
{
    abstract class DataExporter
    {
        public void ReadData()
        {
            Console.WriteLine("Reading the order made by customer");
        }

        public void FormatData()
        {
            Console.WriteLine("Formating the data as requested.");
        }

 
        public abstract void ExportData();

        // Template method 
        public void ExportFormatedData()
        {
            this.ReadData();
            this.FormatData();
            this.ExportData();
        }
    }
}
