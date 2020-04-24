using System;
using System.IO;
using System.Reflection;

namespace RestaurantDP.Bridge
{
    public class FileMessage: IDisplayOption
    {
        private static FileMessage fileMessage = null;
        private static readonly object padlock = new object();
        private static readonly string _path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "logs.txt");

        FileMessage()
        {
        }

        public static FileMessage Instance
        {
            get
            {
                if (fileMessage == null)
                {
                    lock (padlock)
                    {
                        if (fileMessage == null)
                        {
                            fileMessage = new FileMessage();
                        }
                    }
                }
                return fileMessage;
            }
        }

        public void sendAction(string action)
        {
            StreamWriter file = File.AppendText(_path);
            file.WriteLine($"{DateTime.Now.ToString()}: {action}");
            file.Close();
        }
    }
}

