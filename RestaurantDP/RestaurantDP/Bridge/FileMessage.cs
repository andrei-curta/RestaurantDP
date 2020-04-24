using System;
namespace RestaurantDP.Bridge
{
    public class FileMessage: IDisplayOption
    {
        private static FileMessage fileMessage = null;
        private static readonly object padlock = new object();

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
            Console.WriteLine(action);
            throw new NotImplementedException();
        }
    }
}
}
