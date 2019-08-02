using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bank
{
    class Money
    {
        public double Balance { get; set; }
        public string Currency { get; set; }
        private string Accountnumber { get; set; }
        private readonly int keyFile;
        public Money(string accountNumber, int keyFile)
        {
            Accountnumber = accountNumber;
            this.keyFile = keyFile;
        }
        public Money(string accountNumber , string currency , int keyFile)
        {
            Balance = 0;
            Accountnumber = accountNumber;
            this.keyFile = keyFile;
            this.Currency = currency;
        }
        public void LockAccountData()
        {
            string textToEncrypt = Balance + "" + Variables.seperator + "" + Currency + Variables.seperator;
            string key = Encryption.GenerateKey(textToEncrypt.Length);
            if(!File.Exists(Variables.AccountsDir + "\\" + Accountnumber + Variables.AccountFileExt))
            {
                File.Create(Variables.AccountsDir + "\\" + Accountnumber + Variables.AccountFileExt).Close();
            }
            Methods.WriteFile(Variables.AccountsDir + "\\" + Accountnumber+ Variables.AccountFileExt,
                Encryption.Encrypt(textToEncrypt, key));
            Methods.WriteFile(Variables.KeysDir + "\\" + keyFile, key);
            Transaction.Export();
        }
       
        public void UnlockAccountData()
        { 
            string key = Methods.ReadFile(Variables.KeysDir + "\\" + keyFile)[0].ToString();
            string EncryptedData = Methods.ReadFile(Variables.AccountsDir + "\\" + Accountnumber + Variables.AccountFileExt)[0].ToString();
            string DecryptedData = Encryption.Decrypt(EncryptedData, key); 
            var data = Methods.ComplexString(DecryptedData, Variables.seperator);
            Balance = Convert.ToDouble(data[0].ToString().Trim(Variables.seperator));
            Currency = data[1].ToString().Trim(Variables.seperator);
        }
    }
}
