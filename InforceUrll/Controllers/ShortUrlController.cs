using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using InforceUrll.Helpers;
using InforceUrll.Models;
using InforceUrll.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace InforceUrll.Controllers
{
    public class ShortUrlController : Controller
    {
        
        public ActionResult Index()
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {
        
                var urlshorts = context.Urls.ToList();
                ViewBag.ShortUrls = JsonConvert.SerializeObject(urlshorts);
                return View(urlshorts);
            }
        }
        
        [HttpGet]
        public string GetUrls()
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {
                return JsonConvert.SerializeObject(context.Urls.ToList());
            }
            
        } 
        
        [HttpGet]
        [Authorize]
        [Route("/ShortUrl/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include="OriginalUrl")]UrlViewModel model)
        {
            
            
            if (ModelState.IsValid)
            {
                using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
                {
                    Console.WriteLine("here rn");
                    if (context.Urls.Any(x => x.OriginalUrl == model.OriginalUrl))
                    {
                        Console.WriteLine("alread was used");
                        ModelState.AddModelError("", "This url was already used...");
                        return View();
                    }
                    var shortUrl = new ShortUrl
                    {
                        OriginalUrl = model.OriginalUrl,
                        UserId = context.Users.FirstOrDefault(x => x.Email == User.Identity.Name).Id,
                        ShortenedUrl = "default"
                    };
                    context.Urls.Add(shortUrl);
                    context.SaveChanges();
                    
                    var url = context.Urls.Where(x => x.OriginalUrl == model.OriginalUrl).FirstOrDefault();  
                    if (url != null)  
                    {  
                        url.ShortenedUrl = ShortUrlHelper.Encode(url.Id);
                        context.SaveChanges();  
                    }  
                    
                    return View();
                }
                // return RedirectToAction(actionName: nameof(Show), routeValues: new { id = shortUrl.Id });
            }

            return View();
        }
        [Authorize]
        public ActionResult Show(int? id)
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {
                var shortUrl = context.Urls.Find(id);
                ViewData["Path"] = ShortUrlHelper.Encode(shortUrl.Id);
                ViewData["Creator"] = context.Users.FirstOrDefault(x => x.Id == shortUrl.UserId).Email;
                return View(shortUrl);
            }

        }
        
        

         [HttpGet]
          // [Route("/Url/{id?}")]
        public ActionResult RedirectTo(string id)
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {
                var shortUrl = context.Urls.Find(ShortUrlHelper.Decode((id)));
                Console.WriteLine(ShortUrlHelper.Decode((id)));
                return Redirect(shortUrl.OriginalUrl);
            }
            
        }


        [Authorize]
        public ActionResult Delete(int? id)
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {
                if (User.IsInRole("admin"))
                {
                    var shortUrl = context.Urls.Find(id);
                    context.Urls.Remove(shortUrl);
                    context.SaveChanges();
                }
                else
                {
                    var shorturl = context.Urls.Include(u => u.User).FirstOrDefault(u => u.Id == id);
                    if (shorturl.User.Email == User.Identity.Name)
                    {
                        context.Urls.Remove(shorturl);
                        context.SaveChanges();
                    }
                }

                return Redirect("~/ShortUrl/Index");
            }
        }
    }
}
