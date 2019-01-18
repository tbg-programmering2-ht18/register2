using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace register
{
    class Program
    {
        static Dictionary<String, String> userPasswDict = new Dictionary<string, string>();
        static Dictionary<String, Animal> userAnimalDict = new Dictionary<string, Animal>();
        static void Main(string[] args)
        {
            userPasswDict.Add("Adam", "123");
            userPasswDict.Add("Rickard", "321");
            userPasswDict.Add("PV", "111");

            userAnimalDict.Add("Adam", new Animal("Cat", "Doggo", "Chirp", false));

            bool userLoggedIn = false;
            bool done = false;

            string registredPassw = "";

            while (!done)
            {
                Console.Write("Enter your username:");
                String user = Console.ReadLine();

                bool userExist = userPasswDict.TryGetValue(user, out registredPassw);
                if (userExist)
                {
                    Console.Write("Enter your password: ");
                    String passw = ReadPassword();
                    if (passw.CompareTo(registredPassw) == 0)
                    {
                        Console.WriteLine("Welcome {0}! You are now logged in!", user);

                        Animal registredAnimal;
                        bool animalExist = userAnimalDict.TryGetValue(user, out registredAnimal);
                        if (animalExist)
                        {
                            Console.WriteLine("this is your animal:{0}", registredAnimal.Show());
                        }
                        else
                        {
                            Console.WriteLine("Sorry there was no animal registred for you.");
                        }

                        Console.WriteLine("Enter any key to log out and exit...");
                        done = true;
                        userLoggedIn = false;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You entered the wrong password");
                    }

                }
                else
                {
                    Console.WriteLine("the user {0} is not found", user);
                    Console.Write("try again? (enter yes or no):");
                    String answer = Console.ReadLine();
                    done = (!answer.ToLower().StartsWith("y"));
                }
            }
        }
        private static string ReadPassword()
        {
            String pass = "";
            ConsoleKeyInfo key = Console.ReadKey(true);
            while(key == null || key.Key != ConsoleKey.Enter)
            {
                pass += key.KeyChar; //Pass = pass + keyChar
                Console.Write("*");
                key = Console.ReadKey(true);
            }
            return pass;
        }
    }
}

