using System;
namespace RestaurantDP.Bridge
{
    class ApplicationMode : IApplicationMode
    {

        private static ApplicationMode applicationMode = null;
        private static readonly object padlock = new object();

        public IDisplayOption DisplayOption { get; set; }

        ApplicationMode()
        {
        }

        public ApplicationMode(IDisplayOption displayOption)
        {
            DisplayOption = displayOption;
        }

        public static ApplicationMode Instance
        {
            get
            {
                if (applicationMode == null)
                {
                    lock (padlock)
                    {
                        if (applicationMode == null)
                        {
                            applicationMode = new ApplicationMode();
                        }
                    }
                }
                return applicationMode;
            }
        }

        public void sendAction(string message)
        {
            DisplayOption.sendAction(message);
        }
    }
}
