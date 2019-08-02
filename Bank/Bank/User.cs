using System;
using System.IO;
using System.Text;

namespace Bank
{
    class User
    {
        private string name;
        private string password;
        
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        static readonly string[] Currencies = { "USD", "NIS", "EURO" };

        // If the user exists in the system
        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        /**
         * Login to the account.  
         * The function checks if there is a file with the username. 
         * If there is file then the function compares the passwords.
         * split[0] = password
         * split[1] = currency
         * split[2] = account number
         * split[3] = key file
         */
        public void LogIn(bool newAccount)
        {
            Account account;
            string file = Variables.UserDir + "\\" + Name + Variables.UserFileExt;
            string line = Methods.ReadFile(file)[0].ToString();
            var split = Methods.ComplexString(line, Variables.seperator);
            if(File.Exists(file) && split[0].Trim(Variables.seperator).Equals(Password))
            {
                if (newAccount)
                {
                    account = new Account(split[2].Trim(Variables.seperator), split[1].Trim(Variables.seperator) ,
                                            Convert.ToInt32(split[3].Trim(Variables.seperator)), this);
                }
                else
                {
                    account = new Account(split[2].Trim(Variables.seperator), Convert.ToInt32(split[3].Trim(Variables.seperator)), this);
                }
                account.InsideAccount();
            }
            else
            {
                Console.WriteLine("There is no match between your password and username. Please try again");
                Console.WriteLine("Username:");
                Name = Console.ReadLine();
                Console.WriteLine("Password:");
                Password = Encryption.GetHashString(Methods.HidePassword());
                LogIn(false);
            }
        }

        //Creates new user in the bank
        public static  void CreateNewAccount()
        { 
            Console.Clear();
            
            Console.WriteLine("Enter username:");
            string name = Console.ReadLine();
            while(File.Exists(Variables.UserDir + "\\" + name +Variables.UserFileExt))
            {
                Console.WriteLine("Sorry but this username is already exists in the system.\r\n Please pick another one:");
                name = Console.ReadLine();
            }
            File.Create(Variables.UserDir + "\\" + name + Variables.UserFileExt).Close();
            Console.WriteLine("Enter password:");
            string hashedPassword = Encryption.GetHashString(Methods.HidePassword());
            Console.WriteLine("Please enter the password again:");
            while (!Encryption.GetHashString(Methods.HidePassword()).Equals(hashedPassword))
            {
                Console.WriteLine("There is no match between the passwords!\r\n Please re-enter the password:");  
            }

            Console.Clear();
            //Choosing the currency
            Console.WriteLine("Choose the currency from the list below: \r\n " +
                "(Example 1 for USD)");
            for(int i = 0;i<Currencies.Length;i++)
            {
                Console.WriteLine((i + 1) +". "+ Currencies[i]);
            }
            string currency = Currencies[Convert.ToInt32(Console.ReadLine()) - 1];
            string accountNumber = GenerateAccountNumber(Variables.AccountNumberLength);
            //Write to the file
            using (StreamWriter sw = File.CreateText(Variables.UserDir + "\\" + name + Variables.UserFileExt))
            {
                sw.Write(hashedPassword + Variables.seperator + currency +
                    Variables.seperator + accountNumber+ Variables.seperator + Variables.key_serial_number+ Variables.seperator);
                sw.Close();
            }
            File.Create(Variables.KeysDir + "\\" + Variables.key_serial_number).Close();
            using (StreamWriter sw = File.CreateText(Variables.KeysFile))
            {
                sw.Write(Convert.ToInt32( Variables.key_serial_number)+1);
                sw.Close();
            }
            User user1 = new User(name , hashedPassword);
            user1.LogIn(true);
        }
        private static string GenerateAccountNumber(int length)
        {
            StringBuilder sb = new StringBuilder();
            Random r = new Random();
            for(int i =0; i< length; i++)
            {
                sb.Append(r.Next(1,10));
            }
            if(File.Exists(Variables.AccountsDir+"\\"+sb.ToString()+Variables.AccountFileExt))
            {
                return GenerateAccountNumber(length);
            }
            return sb.ToString();
        }
        
    }
}
