using System;
using System.Web.Mvc;
using System.Text;
using OriginalCardGen.Models;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace OriginalCardGen.Controllers
{
    public class LoginController : Controller
    {
        DB _db = new DB();

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult ValidateLogin(string user, string password)
        {
            if ((user == "" || user == null) || (password == "" || password == null))
            {
                TempData["Message"] = "The fields cannot be empty";
                return View("LoginPage");
            }
            var q = _db.AccountTables;

            SqlConnection sqlConn = new SqlConnection(GlobalVariables.sqlConnStr);
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = sqlConn.CreateCommand();
            var encodedPass = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            DataTable dt = new DataTable();
            SqlCommand getCredentials = new SqlCommand("select userEmail, userPass from dbo.AccountTables where userEmail= '" + user + "' and userPass = '" + encodedPass + "'", sqlConn);
            sqlConn.Open();
            var db_user = "";
            var db_pass = "";

            SqlDataReader reader = getCredentials.ExecuteReader();

            string decodedString = "";
            while (reader.Read())
            {
                db_user = reader.GetString(0);
                db_pass = reader.GetString(1);

                if (db_pass != null)
                {
                    decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(db_pass));
                }
            }


            sqlConn.Close();


            if (user == db_user && password == decodedString)
            {
                GlobalVariables.isSeshActive = true;
                Session["User"] = db_user;
                Session["CurrentPass"] = decodedString;

                TempData["Message"] = "";
                var test = db_user.Split('@')[0];
                Session["usrName"] = test;

                string path = Path.Combine(Server.MapPath("~/"), "Images", db_user);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return Redirect("~/Home/Index");
            }
            TempData["Message"] = "The email or password are incorrect";
            return View("LoginPage");
        }


        [HttpGet]
        public ActionResult KillSesh()
        {
            Session.Clear();
            Session.RemoveAll();
            return Redirect("~/Login/LoginPage/");

        }

 

        [HttpGet]
        public ActionResult AddUser(string email, string role, string temp_pass, string conf_temp)
        {
            var q = _db.AccountTables;

            var encodedPass = Convert.ToBase64String(Encoding.UTF8.GetBytes(temp_pass));

            q.Add(new AccountTable()
            {
                userEmail = email,
                userPass = encodedPass,
            });

            _db.SaveChanges();

            return Content("true");

        }


        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ValidateRegistration(string user, string firstpassword, string secondpassword)
        {
            var q = _db.AccountTables;
            if ((user == "" || user == null) || (firstpassword == "" || firstpassword == null) || (secondpassword == "" || secondpassword == null))
            {
                TempData["Message"] = "The fields cannot be empty";
                return View("Register");
            }
            else if (firstpassword != secondpassword)
            {
                TempData["Message"] = "Passwords don't match!";
                return View("Register");
            }

            SqlConnection sqlConn = new SqlConnection(GlobalVariables.sqlConnStr);
            SqlCommand getCredentials = new SqlCommand("select userEmail from dbo.AccountTables where userEmail= '" + user + "'", sqlConn);

            sqlConn.Open();

            SqlDataReader reader = getCredentials.ExecuteReader();

            if (reader.Read())
            {
                TempData["Message"] = "Email is already registered!";
                sqlConn.Close();
                return View("Register");
            }
            sqlConn.Close();

            var encodedPass = Convert.ToBase64String(Encoding.UTF8.GetBytes(firstpassword));

            try
            {
                _db.AccountTables.Add(new AccountTable()
                {
                    userEmail = user,
                    userPass = encodedPass,
                });
                int s = _db.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.StackTrace}");
            }


            TempData["Message_Green"] = "User has been succesfully created! You can now log in with the new credentials.";
            return View("LoginPage");
        }
    }
}