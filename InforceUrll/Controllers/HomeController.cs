using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InforceUrll.Models;

namespace InforceUrll.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult About()
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {
                var contentstr = context.AboutStrs.Find(1);
                return View(contentstr);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult About(AboutContent contentstr)
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {
                AboutContent content = context.AboutStrs.Find(1);
                content.AlgoStr = contentstr.AlgoStr;
                context.SaveChanges();
                return View(contentstr);
            }
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}