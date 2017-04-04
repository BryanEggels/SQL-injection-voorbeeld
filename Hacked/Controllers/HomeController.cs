using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Hacked.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string email, string password)
        {
            using(SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"c:\\users\\fam_e\\onedrive\\documenten\\visual studio 2015\\Projects\\Hacked\\Hacked\\App_Data\\Database.mdf\";Integrated Security = True"))
            {
                con.Open();
                string query = "SELECT Email FROM [User] WHERE Email = '" + email + "' AND Password = '" + password + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                
                string goedequery = "SELECT Email FROM [User] WHERE Email = @email AND Password = @password";

                SqlCommand goedecmd = new SqlCommand(goedequery, con);

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                
                if(cmd.ExecuteScalar() != null)
                {
                    Session["User"] = email;
                }
                return RedirectToAction("Index", "Home");

            }
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
