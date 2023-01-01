using System.Linq;
using System.Web.Mvc;
using InforceUrll.Helpers;
using InforceUrll.Models;

namespace InforceUrll.Controllers
{
    public class ShortUrlController : Controller
    {
        
        public ActionResult Index()
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {

                var urlshorts = context.Urls.ToList();
                return View(urlshorts);
            }
        }
        
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string originalUrl)
        {
            var shortUrl = new ShortUrl
            {
                OriginalUrl = originalUrl
            };
            
            if (ModelState.IsValid)
            {
                using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
                {
                    context.Urls.Add(shortUrl);
                    context.SaveChanges();
                }

                // return RedirectToAction(actionName: nameof(Show), routeValues: new { id = shortUrl.Id });
            }

            return View(shortUrl);
        }
        [Authorize]
        public ActionResult Show(int? id)
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {
                var shortUrl = context.Urls.Find(id);
                ViewData["Path"] = ShortUrlHelper.Encode(shortUrl.Id);
                return View(shortUrl);
            }

        }
        
        

        [HttpGet]
        [Route("/ShortUrls/RedirectTo/{path:required}")]
        public ActionResult RedirectTo(string path)
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {
                var shortUrl = context.Urls.Find(ShortUrlHelper.Decode((path)));
                return Redirect(shortUrl.OriginalUrl);
            }
            
        }

        public ActionResult Delete(int? id)
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {
                
                var shortUrl = context.Urls.Find(id);
                context.Urls.Remove(shortUrl);
                return Redirect(shortUrl.OriginalUrl);
            }
        }
    }
}
