using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace RestaurantDP.Template
{
    abstract class DataExporter
    {
        protected string _basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        protected string _fullPath;
        protected string _baseTitle;
        protected string _data;
        protected string _footer;
        protected string _extension;

        public void ReadData<T>(string title, IEnumerable<T> dataArray, string footer = "")
        {
            _baseTitle = title;
            _footer = footer;

            foreach(T data in dataArray)
            {
                _data += data.ToString() + "\n"; 
            }
        }

        public void FormatData()
        {
            _data = $"{_baseTitle}\n_______\n{_data}\n{_footer}\n______\nDate: {DateTime.Now}";
        }

        private void GeneratePath()
        {
            _fullPath = $"{_basePath}\\..\\{_baseTitle}_{DateTime.Now.ToOADate()}";
        }
 
        private void OpenFile()
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo($"{_fullPath}.{_extension}")
            {
                UseShellExecute = true
            };
            p.Start();
        }

        public abstract void ExportData();

        // Template method 
        public void ExportFormatedData<T>(string title, IEnumerable<T> dataArray, string footer = "")
        {
            ReadData( title, dataArray);
            FormatData();
            GeneratePath();
            ExportData();
            OpenFile();
        }
    }
}
