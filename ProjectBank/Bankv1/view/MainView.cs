using System;
using Bankv1.utility;
using Bankv1.controller;
using Bankv1.entity;

namespace Bankv1.view
{
    public class MainView
    {
        private static AccountController controller = new AccountController();
        public static void GenerateMenu()
        {
            while (true)
            {
                if (Program.currentLoggedIn == null)
                {
                    GenerateGeneralMenu();
                }

                else
                {
                    GenerateCustomerMenu();
                }
            }
        }

        private static void GenerateGeneralMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.Out.Flush();
                Console.WriteLine("-------------------- Welcome to ErolarBank --------------------");
                Console.WriteLine("1. Register for free.");
                Console.WriteLine("2. Login.");
                Console.WriteLine("3. Exit.");
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("Please enter your choice (1|2|3):");
                var choice = Utility.GetInt32Number();
                switch (choice)
                {
                    case 1:
                        controller.Register();
                        break;
                    case 2:
                        if (controller.Dologin())
                        {
                            Console.WriteLine("Login success!");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Thank you for using our service, /n See you again.");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                if (Program.currentLoggedIn != null)
                {
                    break;
                }
            }
        }
        private static void GenerateCustomerMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.Out.Flush();
                Console.WriteLine("-------------------- Welcome Back --------------------");
                Console.WriteLine("1. Veryfi account balance.");
                Console.WriteLine("2. Withdraw.");
                Console.WriteLine("3. Deposit.");
                Console.WriteLine("4. Transfer.");
                Console.WriteLine("4. Exit.");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("Please enter your choice (1|2|3|4|5):");
                var choice = Utility.GetInt32Number();
                switch (choice)
                {
                    case 1:
                        
                        
                }
            }
        }
    }
}