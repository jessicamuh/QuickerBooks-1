using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace QuickerBooksApp.Models
{
    public class AccountsModel
    {
        public string AccountName { get; set; }
        public int AccountNumber { get; set; }
        public string AccountDescription { get; set; }
        public string NormalSide { get; set; }
        public string AccountCategory { get; set; }
        public string AccountSubcategory { get; set; }
        public int InitialBalance { get; set; }
        public int Debit { get; set; }
        public int Credit { get; set; }

        public int Balance { get; set; }
        public int AccountOrder { get; set; }
        public string AccountState { get; set; }
        public string Comment { get; set; }


    }
}