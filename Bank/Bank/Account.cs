using System;
using System.Collections.Generic;
using System.IO;

namespace Bank
{
    class Account
    {
        private string AccountNumber { get; set; }
        private Money AccountMoney { get ; set ; }
        private User user { get; set; }
        private readonly string[] commands = {"Deposit" , "Withdraw" , "Transfer money to another account"
        ,"Log Out" , "Delete account"};
        //Constructor for existing account
        public Account( string AccountNumber , int keyFile , User user)
        {
            this.AccountNumber = AccountNumber;
            AccountMoney = new Money(AccountNumber ,keyFile);
            this.user = user;

        }
        //Constructor for new account
        public Account(string AccountNumber , string Currency , int keyFile , User user)
        {
            this.AccountNumber = AccountNumber;
            AccountMoney = new Money(AccountNumber ,Currency , keyFile);
            AccountMoney.LockAccountData();
            this.user = user;
        }

        /// <summary>
        ///     Add money to the account
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>
        ///     true if the amount is greater than 0
        ///     otherwise returns false.
        /// </returns>
        private bool Deposit()
        {
            double amount;
            Console.Clear();
            Console.WriteLine("How much do you want to deposit?"); 
            try
            {
                amount = Convert.ToDouble(Console.ReadLine());
            }
            catch(Exception)
            {
                return Deposit();
            }
            if (amount > 0)
            {
                AccountMoney.Balance += amount;

            }
            Transaction.WriteTransaction(TransactionTypes.Deposit, amount
                + " " + AccountMoney.Currency + " was added to " + AccountNumber);
            return true;
        }

        private bool Withdraw()
        {
            double amount;
            Console.Clear();
            Console.WriteLine("How much do you want to withdraw from your account?");
            try
            {
                amount = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                return Withdraw();
            }
            if (amount>0 && AccountMoney.Balance>0&& AccountMoney.Balance-amount>=0)
            {
                AccountMoney.Balance -= amount ;
            }
            else
            {
                Console.WriteLine("You can only withdraw up to" + AccountMoney.Balance + "" +
                    AccountMoney.Currency);
                Console.ReadKey();
                return Withdraw();
            }
            Transaction.WriteTransaction(TransactionTypes.Withdraw, amount
               + " " + AccountMoney.Currency + " removed from " + AccountNumber);
            return true;
        }
        private bool Withdraw(double amount)
        {
            if (amount > 0 && AccountMoney.Balance > 0 && AccountMoney.Balance - amount >= 0)
            {
                AccountMoney.Balance -= amount;
            }
            else
            {
                Console.WriteLine("You can only withdraw up to " + AccountMoney.Balance + "" +
                    AccountMoney.Currency);
                Console.ReadKey();
                return Withdraw();
            }
            return true;
        }
        private void Transfer()
        {
        }

        private void DeleteAccount()
        {
            var data = Methods.ReadFile(Variables.UserDir + "\\" + user.Name + Variables.UserFileExt);
            var AccountData = Methods.ComplexString(data[0].ToString() , Variables.seperator);
            File.Delete(Variables.UserDir + "\\" + user.Name + Variables.UserFileExt);
            File.Delete(Variables.KeysDir + "\\" + AccountData[3].Trim(Variables.seperator));
            File.Delete(Variables.AccountsDir + "\\" + AccountNumber +Variables.AccountFileExt);
        }
        public void InsideAccount()
        {
            Console.Clear();
            AccountMoney.UnlockAccountData();
            int ac = 0; // Can be any number except 3 or 4 
            while(ac != 4 &&ac !=3)
            {
                Console.WriteLine("Account Number: " + AccountNumber);
                Console.WriteLine("Balance: " + Math.Round(AccountMoney.Balance , 4) + " " + AccountMoney.Currency);
                Console.WriteLine("");
                Console.WriteLine("Choose an action from the list below");
                Console.WriteLine("");
                for (int i = 0; i < commands.Length; i++)
                {
                    Console.WriteLine((i + 1) + "." + commands[i]);
                }
                int action = CheckSelectedAction(ParseInput());
                switch (action)
                {
                    case 0:
                        Deposit();
                        break;
                    case 1:
                        Withdraw();
                        break;
                    case 2:
                        //Transfer();
                        break;
                    case 3:
                        AccountMoney.LockAccountData();
                        break;
                    case 4:
                        DeleteAccount();
                        break;
                    default:
                        break;
                }
                Console.Clear();
                ac = action;
            }    
        }
        private bool ValaidateAccountNumber(int number)
        {
            string input = number.ToString();
            if(input.Length == Variables.AccountNumberLength)
            {
                if(File.Exists(Variables.AccountsDir+"\\" + input + Variables.AccountFileExt))
                {
                    return true;
                }
            }
            return false;
        }

        private int ParseInput()
        {
            int action;
            try
            {
                action = Convert.ToInt32(Console.ReadLine())-1;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't parse the input. Please try again");
                return ParseInput();
            }
            return action;
        }
        private int CheckSelectedAction(int op)
        {
            if (op>commands.Length)
            {
                Console.WriteLine("The input " + (op + 1) + " is not valid ");
                op = ParseInput();
                return CheckSelectedAction(op);
            }
            return op;
        }
    }
}
