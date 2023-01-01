using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using InforceUrll.Models;
using InforceUrll.Models.ViewModels;

namespace InforceUrll.Controllers
{
    public class AccountController : Controller
    {
        private readonly DBUrlContext.DBUrlContext _context;

        public AccountController(DBUrlContext.DBUrlContext context)
        {
            _context = context;
        }
        public AccountController()
        {
           
        }
        
        [HttpGet]
        public ActionResult Login() 
        {
            Debug.WriteLine("in login get rn");
            return View(); 
        }
        
        [HttpPost]
        public ActionResult Login([Bind(Include="Email,Password")]LoginViewModel model) 
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {
                bool IsValidUser = context.Users.Any(user => user.Email ==
                    model.Email && user.Password == model.Password);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "invalid Email or Password");
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult Register() 
        { 
            return View(); 
        }
        
        [HttpPost]
        public ActionResult Register(RegisterViewModel model) 
        {
            using (DBUrlContext.DBUrlContext context = new DBUrlContext.DBUrlContext())
            {
                context.Users.Add(new User{Email = model.Email, Password = model.Password, RoleId = 2});
                context.SaveChanges();
                return RedirectToAction("Login");
            }
              
        }
        

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AccessDenied()
        {   
            return View();
        }
        
        
        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        // GET: Account
        // public async Task<IActionResult> Index()
        // {
        //       return _context.Urls != null ? 
        //                   View(await _context.Urls.ToListAsync()) :
        //                   Problem("Entity set 'DBUrlContext.Urls'  is null.");
        // }
        //
        // // GET: Account/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null || _context.Urls == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var shortUrl = await _context.Urls
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (shortUrl == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return View(shortUrl);
        // }
        //
        // // GET: Account/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }
        //
        // // POST: Account/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,OriginalUrl")] ShortUrl shortUrl)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(shortUrl);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(shortUrl);
        // }
        //
        // // GET: Account/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null || _context.Urls == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var shortUrl = await _context.Urls.FindAsync(id);
        //     if (shortUrl == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(shortUrl);
        // }
        //
        // // POST: Account/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Id,OriginalUrl")] ShortUrl shortUrl)
        // {
        //     if (id != shortUrl.Id)
        //     {
        //         return NotFound();
        //     }
        //
        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(shortUrl);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!ShortUrlExists(shortUrl.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(shortUrl);
        // }
        //
        // // GET: Account/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null || _context.Urls == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var shortUrl = await _context.Urls
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (shortUrl == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return View(shortUrl);
        // }
        //
        // // POST: Account/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     if (_context.Urls == null)
        //     {
        //         return Problem("Entity set 'DBUrlContext.Urls'  is null.");
        //     }
        //     var shortUrl = await _context.Urls.FindAsync(id);
        //     if (shortUrl != null)
        //     {
        //         _context.Urls.Remove(shortUrl);
        //     }
        //     
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }
        //
        // private bool ShortUrlExists(int id)
        // {
        //   return (_context.Urls?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
    }
}