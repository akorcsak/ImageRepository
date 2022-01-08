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
                List<ListItem> files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {
                    string fileName = Path.GetFileName(filePath);
                    files.Add(new ListItem(fileName, Path.Combine("Images", fileName)));
                }

                return View(files);
            }

            return Redirect("~/Login/LoginPage");
        }

        public ActionResult DeleteFiles(string[] fileName)
        {
            string userName = (string)Session["User"];
            string[] filePaths = Directory.GetFiles(Path.Combine(Server.MapPath("~/"), "Images", userName));
            var logPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Logs/log.txt");
            var log = new LoggerConfiguration()
                .WriteTo.File(logPath)
                .CreateLogger();

            foreach (string filePath in filePaths)
            {
                log.Information(filePath);

                string file = Path.GetFileName(filePath);
                if (fileName.Contains(file))
                {
                    log.Information("True");
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