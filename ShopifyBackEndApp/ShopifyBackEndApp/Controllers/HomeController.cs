﻿using System;
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

        public ActionResult DeleteFiles(string fileName)
        {
            string userName = (string)Session["User"];
            string[] files = Directory.GetFiles(Server.MapPath("~/Images/" + userName));
            foreach (string file in files)
            {
                if (file == fileName)
                {
                    System.IO.File.Delete(fileName);
                }
                Console.WriteLine($"{fileName} is deleted.");
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}