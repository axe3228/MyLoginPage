using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLoginPage.Models;
using System.Data.SqlClient;

namespace MyLoginPage.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection oConnection = new SqlConnection();
        SqlCommand oCommand = new SqlCommand();
        SqlDataReader oReader;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void getConnectionString()
        {
            oConnection.ConnectionString = "Data Source = localhost; Database = DatabaseTesting; Integrated Security = SSPI;";
        }

        [HttpPost]
        public ActionResult Verify(Account acct)
        {
            getConnectionString();
            oConnection.Open();
            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT * FROM Account WHERE acctUsername='"+acct.Name+"' AND acctPassword='"+acct.Password+"'";
            oReader = oCommand.ExecuteReader();
            if (oReader.Read())
            {
                oConnection.Close();
                return Content("<script language='javascript' type='text/javascript'>alert     ('Requested Successfully ');</script>");
            } 
            else
            {
                oConnection.Close();
                return Content("<script language='javascript' type='text/javascript'>alert     ('Requested Failed ');</script>");
            }         
        }
    }
}