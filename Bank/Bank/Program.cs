using System;
using System.IO;
namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize the program
            BuildDirectoryStructure();
            BuildFilesStructure();
            InitVariables();

            //Printing
            Console.WriteLine("Welcome to the bank");
            Console.WriteLine("Do you have an account or do you want to create new one?" +
                "\r\n" + "To choose an option, write it's number");
            int selectedOption = CheckSelectedOption(ChooseOption());
            if(selectedOption == 0)
            {
                Console.Clear();
                Console.WriteLine("Enter your username: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                string password = Encryption.GetHashString(Methods.HidePassword());
                User user = new User(name, password);
                user.LogIn(false);
            }
            else
            {
                User.CreateNewAccount();
            }
        }
        
        private static void BuildDirectoryStructure()
        {
            if (!Directory.Exists(Variables.MainDir))
            {
                Directory.CreateDirectory(Variables.MainDir);
            }
            if (!Directory.Exists(Variables.AccountsDir))
            {
                Directory.CreateDirectory(Variables.AccountsDir);
            }
            if (!Directory.Exists(Variables.UserDir))
            {
                Directory.CreateDirectory(Variables.UserDir);
            }
            if(!Directory.Exists(Variables.KeysDir))
            {
                Directory.CreateDirectory(Variables.KeysDir);
            }
        }
        private static void BuildFilesStructure()
        {
            if(!File.Exists(Variables.KeysFile))
            {
                File.Create(Variables.KeysFile).Close();
                using (StreamWriter sw = File.CreateText(Variables.KeysFile))
                {
                    sw.Write(0);
                    sw.Close();
                }
            }
        }
        private static void InitVariables()
        {
            if (!File.Exists(Variables.KeysFile))
            {
                Variables.key_serial_number = 0;
            }
            else
            {
                Variables.key_serial_number = Convert.ToInt32(Methods.ReadFile(Variables.KeysFile)[0]);
            }
        }
        private static int ChooseOption()
        {
            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine((i + 1) + "." + " Login to an existing account");
                        break;
                    case 1:
                        Console.WriteLine((i + 1) + "." + " Create new account");
                        break;
                    default:
                        break;
                }
            }
            string s = Console.ReadLine();
            int option;
            try
            {
                option = Convert.ToInt32(s) - 1;
                
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Couldn't parse the input. Please try again ");
                return ChooseOption();
            }

            return option;
        }
        private static int CheckSelectedOption(int op)
        {
            if(op != 0 && op != 1)
            {
                Console.WriteLine("The input " + (op + 1) + " is not valid ");
                op = ChooseOption();
                return CheckSelectedOption(op);
            }
            return op;
        }

    }
}
