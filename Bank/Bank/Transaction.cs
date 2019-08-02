using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Bank
{
    public enum TransactionTypes { Deposit, Withdraw, Transfer_Of_Money }

    class Transaction
    {
        private static readonly StringBuilder sb = new StringBuilder();
        private static readonly List<string> Transactions = new List<string>();
        private static readonly ArrayList TransactionNumbers = new ArrayList();
        public static void WriteTransaction(TransactionTypes type , string data)
        {
            //Saves the transtaction inside a list 
            string id = GenerateTransactionIdString();
            sb.Append(type.ToString() + Variables.seperator+id
                +Variables.seperator + data + Variables.seperator);
            TransactionNumbers.Add(id);
            Transactions.Add(sb.ToString());
            sb.Clear();
        }
        public static void Export()
        {
            //Writes the data from the list to the xml file


        }
        private static string GenerateTransactionIdString()
        {
            // Generates the id number of the transaction
            StringBuilder id = new StringBuilder();
            for(int i = 0; i<TransactionNumbers.ToArray().Length;i++)
            {
                if (id.ToString().Equals(TransactionNumbers[i]))
                {
                    return GenerateTransactionIdString();
                }
            }
            return id.ToString();
        }
    }
}
