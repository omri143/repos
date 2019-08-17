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
        public static void WriteTransaction(TransactionTypes type , string data)
        {
            //Saves the transtaction inside a list 
            string id = GenerateTransactionIdString(type);
            sb.Append(type.ToString() + Variables.seperator+id
                +Variables.seperator + data + Variables.seperator);
            Transactions.Add(sb.ToString());
            sb.Clear();
        }
        public static void Export()
        {
            //Writes the data from the list to the xml file


        }
        private static string GenerateTransactionIdString(TransactionTypes type)
        {
            StringBuilder id = new StringBuilder();

            switch (type)
            {
                case TransactionTypes.Deposit:
                    id.Append("D");
                    break;
                case TransactionTypes.Withdraw:
                    id.Append("W");
                    break;
                case TransactionTypes.Transfer_Of_Money:
                    id.Append("T");
                    break;
                default:
                    break;
            }
            // Generates the id number of the transaction
            var data = Methods.ReadFile(Variables.UsedTransactionsIds);
            for(int i = 0; i<data.Count;i++)
            {
                if (id.ToString().Equals(data[i]))
                {
                    return GenerateTransactionIdString(type);
                }
            }
            return id.ToString();
        }
    }
}
