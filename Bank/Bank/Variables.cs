using System;
using System.Collections;
using System.IO;

namespace Bank
{
    class Variables
    {
        //Files And Directories
        public static readonly string MainDir = "C:\\Users\\" + Environment.UserName + "\\Bank";
        public static readonly string AccountsDir = MainDir + "\\Accounts";
        public static readonly string UserDir = MainDir + "\\Users";
        public static readonly string KeysDir = MainDir + "\\Keys";
        public static readonly string KeysFile= KeysDir + "\\serial.key";
        public static readonly string XmlFile = MainDir + "\\Transactions.xml";
        public static readonly string UsedTransactionsIds = MainDir + "\\ UsedIds";
       
        //File Extensions
        public static readonly string AccountFileExt = ".acc";
        public static readonly string UserFileExt = ".usr";

        //Numbers Length
        public static readonly int AccountNumberLength = 10;
        public static readonly int TransactionNumberLength = 5;

        //Misc
        public static readonly char seperator = '&';
        public static int key_serial_number;


    }
}
