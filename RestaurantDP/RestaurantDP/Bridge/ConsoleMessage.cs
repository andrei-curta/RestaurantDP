using System;
namespace RestaurantDP.Bridge
{
    public sealed class ConsoleMessage: IDisplayOption
    {

        private static ConsoleMessage consoleMessage = null;
        private static readonly object padlock = new object();

        ConsoleMessage()
        {
        }

        public static ConsoleMessage Instance
        {
            get
            {
                if (consoleMessage == null)
                {
                    lock (padlock)
                    {
                        if (consoleMessage == null)
                        {
                            consoleMessage = new ConsoleMessage();
                        }
                    }
                }
                return consoleMessage;
            }
        }

        public void sendAction(string action)
        {
            Console.WriteLine(action);
            throw new NotImplementedException();
        }
    }
}
