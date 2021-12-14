using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ShopifyBackEndApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string userName = (string)Session["User"];
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/" + userName));
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                files.Add(new ListItem(fileName, "~/Images/" + fileName));
            }


            return View(files);
        }

        public ActionResult DeleteFiles(string[] fileName)
        {
            string userName = (string)Session["User"];
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/" + userName));
            foreach (string filePath in filePaths)
            {
                string file = Path.GetFileName(filePath);
                if (fileName.Contains(file))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            return View();
        }

        public ActionResult UploadFiles()
        {
            if (Request.Files.Count > 0)
            {
                string userName = (string)Session["User"];
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var fileName = Path.GetFileName(Request.Files[i].FileName);
                    Request.Files[i].SaveAs(Path.Combine(@"C:\Users\Andrei\source\repos\ShopifyBackEnd2022\ShopifyBackEndApp\ShopifyBackEndApp\Images\" + userName, fileName));
                }
            }

            return RedirectToAction("Index");
        }

    }
}