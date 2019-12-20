using loginentityF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace loginentityF.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(user User)
        {
            List<user> ManagersList = new List<user>();
            List<user> AssManagersList = new List<user>();

            if (Session["Managers"] == null)
            {
                Session["Managers"] = ManagersList;
            }
            else
            {
                ManagersList = (List<user>) Session["Managers"];
            }

            if (Session["AssManagers"] == null)
            {
                Session["AssManagers"] = AssManagersList;
            }
            else
            {
                AssManagersList = (List<user>)Session["AssManagers"];
            }


            if (ModelState.IsValid)
            {
                Session["Name"] = User.userName;
                Session["Password"] = User.password;
                Session["Designation"] = User.designation;

                if (User.designation == "Managers")
                {
                    ManagersList.Add(User);
                    Session["Managers"] = ManagersList;

                }
                else if(User.designation == "Assistent Managers")
                {
                    AssManagersList.Add(User);
                    Session["AssManagers"] =AssManagersList;
                }


            }
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(user User)
        {
            //List<string> Manager = new List<string>();
            //List<string> AssistantManager = new List<string>();
            List<user> users = (List<user>)Session["Managers"];

            users.AddRange((List<user>)Session["AssManagers"]);

            if (ModelState.IsValid)
            {
                for(int i = 0; i < users.Count; i++)
                {
                    if (users[i].userName == User.userName &&users[i].password == User.password)
                    {
                        return RedirectToAction("ShowUser", users[i]);
                    }
                }
                
                
                //Session["Designation"] = User.designation;
                //Session["Name"] = User.userName;
                //Session["Password"] = User.password;
                //string[,] strTo2D = { { User.userName }, { User.password } };
               // Session["str2DArray"] = strTo2D;
            }
            return RedirectToAction("ShowUser");
        }
        public ActionResult ShowUser(user User)
        {

            //Session["Name"] = User.userName;
            //Session["Password"] = User.password;
            List<user> users = null;
            if (User.designation == "Managers")
            {
                users = (List<user>)Session["AssManagers"];

            }
            else if (User.designation == "Assistent Managers")
            {

            }
            else if (User.designation == "Super Admin")
            {
                users = (List<user>)Session["Managers"];

                users.AddRange((List<user>)Session["AssManagers"]);
            }


            //users = (List<user>)Session["Managers"];

            //users.AddRange((List<user>)Session["AssManagers"]);
            return View(users);
        }
        public ActionResult v()
        {
            return View();
        }

        public ActionResult v3()
        {
            return View();
        }
    }
}