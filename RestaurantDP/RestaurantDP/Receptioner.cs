using Repository;
using RestaurantDP.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP
{
    class Receptioner
    {
        private UserRepository _repository = new UserRepository(new MyContext());

        public User GreetClient()
        {
            Console.WriteLine("Welcome to our restaurant");
            Console.WriteLine("Can I have your name please?");

            string name = Console.ReadLine();
            User client = _repository.GetByName(name);

            if(client == null)
            {
                Console.WriteLine("I'm afraid you are not a member of our restaurant");
                Console.WriteLine("Would you like to join?\n"+
                                  "1 -> Yes\n" +
                                  "2 -> No\n");

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        return RegisterClient(name);
                    case 2:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Goodbye!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("I see you are already in our evidence. A waiter will serve you soon\n");
                return client;
            }

            return null;
        }

        public User RegisterClient(string name)
        {
            User user = new User();
            user.Name = name;

            Console.WriteLine("What type of client are you?");
            foreach (int i in Enum.GetValues(typeof(EOfferType)))
                Console.WriteLine($"{i} - {((EOfferType)i).ToString() }");

            int option = Int32.Parse(Console.ReadLine());
            EOfferType eOfferType = EOfferType.Regular;
            
            if (Enum.IsDefined(typeof(EOfferType), option))
            {
                eOfferType = (EOfferType)option;
            }

            user.OfferType = eOfferType;

            Console.WriteLine("Thank you. A waiter will serve you soon");

            return _repository.Insert(user);
        }
    }
}
