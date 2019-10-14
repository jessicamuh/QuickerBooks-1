using QuickerBooksApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickerBooksApp.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AccountsModel account)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Accounts(AccountName, AccountNumber, AccountDescription, NormalSide, AccountCategory, AccountSubcategory, InitialBalance, Debit, Credit, Balance, AccountOrder, AccountState, Comment, Term) VALUES(@AccountName, @AccountNumber, @AccountDescription, @NormalSide, @AccountCategory, @AccountSubcategory, @InitialBalance, @Debit, @Credit, @Balance, @AccountOrder, @AccountState, @Comment, @Term)";
                query += " SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@AccountName", account.AccountName);
                    cmd.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
                    cmd.Parameters.AddWithValue("@AccountDescription", account.AccountDescription);
                    cmd.Parameters.AddWithValue("@NormalSide", account.NormalSide);
                    cmd.Parameters.AddWithValue("@AccountCategory", account.AccountCategory);
                    cmd.Parameters.AddWithValue("@AccountSubcategory", account.AccountSubcategory);
                    cmd.Parameters.AddWithValue("@InitialBalance", account.InitialBalance);
                    cmd.Parameters.AddWithValue("@Debit", account.Debit);
                    cmd.Parameters.AddWithValue("@Credit", account.Credit);
                    cmd.Parameters.AddWithValue("@Balance", account.Balance);
                    cmd.Parameters.AddWithValue("@AccountOrder", account.AccountOrder);
                    cmd.Parameters.AddWithValue("@AccountState", account.AccountState);
                    cmd.Parameters.AddWithValue("@Comment", account.Comment);
                    cmd.Parameters.AddWithValue("@Term", account.Term);



                    con.Close();
                }
            }

            return View(account);
        }

        public ActionResult View(AccountsModel model)
        {
            return View(model);
        }
    }
}