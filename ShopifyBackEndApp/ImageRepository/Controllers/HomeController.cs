using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using OriginalCardGen.Models;
using Serilog;

namespace ShopifyBackEndApp.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
            {


        }

        public ActionResult Index()
        {
            string userName = (string)Session["User"];

            if(!string.IsNullOrEmpty(userName))
            {
                string[] filePaths = Directory.GetFiles(Path.Combine(Server.MapPath("~/"), "Images", userName));
                //Path.Combine(Server.MapPath("~/"), "Images", db_user)
                var logPath = @"C:\Logs\log.txt";
                var log = new LoggerConfiguration()
                    .WriteTo.File(logPath)
                    .CreateLogger();

                log.Information(userName);

                if (filePaths.Length == 0)
                {
                    return View("EmptyContent");
                }

                else
                {
                    List<ListItem> files = new List<ListItem>();
                    foreach (string filePath in filePaths)
                    {
                        string fileName = Path.GetFileName(filePath);
                        files.Add(new ListItem(fileName, Path.Combine("Images", fileName)));
                    }

                    return View("Index", files);
                }

                
            }

            return Redirect("~/Login/LoginPage");
        }

        public ActionResult DeleteFiles(string[] fileName)
        {
            string userName = (string)Session["User"];
            string[] filePaths = Directory.GetFiles(Path.Combine(Server.MapPath("~/"), "Images", userName));


            foreach (string filePath in filePaths)
            {

                string file = Path.GetFileName(filePath);
                if (fileName.Contains(file))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            

            return RedirectToAction("Index");
        }

        public ActionResult UploadFiles()
        {
            if (Request.Files.Count > 0)
            {
                string userName = (string)Session["User"];
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var fileName = Path.GetFileName(Request.Files[i].FileName);
                    Request.Files[i].SaveAs(Path.Combine(Server.MapPath("~/"), "Images", userName, fileName));
                }
            }

            return RedirectToAction("Index");
        }

    }
}