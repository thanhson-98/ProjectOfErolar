using System;
using Bankv1.entity;
using Bankv1.utility;
using Bankv1.model;


namespace Bankv1.controller
{
    public class AccountController
    {
        private AccountModel model = new AccountModel();

        public void Register()
        {
            Console.WriteLine("Please enter account information");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            Console.WriteLine("Confirm Password: ");
            var cpassword = Console.ReadLine();
            Console.WriteLine("Identity Card: ");
            var identityCard = Console.ReadLine();
            Console.WriteLine("Full Name: ");
            var fullName = Console.ReadLine();
            Console.WriteLine("Email: ");
            var email = Console.ReadLine();
            Console.WriteLine("Phone: ");
            var phone = Console.ReadLine();

            var account = new Account(username, password, cpassword, identityCard, phone, email, fullName);
            var errors = account.checkValid();
            if (errors.Count == 0)
            {
                model.Save(account);
                Console.WriteLine("Register success, Thank you very much.");
                Console.ReadLine();
            }
            else
            {
                Console.Error.WriteLine("Please fix following errors and try again.");
                foreach (var messagErrorsValue in errors.Values)
                {
                    Console.Error.WriteLine(messagErrorsValue);
                }
                Console.ReadLine();
            }
        }
        public Boolean Dologin()
        {
            Console.WriteLine("Please enter account information");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();

            var account = new Account(username, password);

            // Tiến hành validate thông tin đăng nhập. kiểm tra username, password khác null và length > 0.
            var errors = account.ValidLoginInformation();
            if (errors.Count > 0)
            {
                Console.WriteLine("Invalid login information . Please fix errors below.");
                foreach (var messagErrorsValue in errors.Values)
                {
                    Console.Error.WriteLine(messagErrorsValue);
                }
                Console.ReadLine();
                return false;
            }

            account = model.GetAccount

            return true;
        }
    }
}