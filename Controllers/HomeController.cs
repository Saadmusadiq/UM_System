using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UM_System.Data;
using UM_System.Models;

namespace UM_System.Controllers
{
    /*[Authorize(Roles = "Admin")]*/
    [Authorize(Roles = "Admin,Super Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DbContextcs.ApplicationDbContext _context ;

        private int age = 0;

        public HomeController(ILogger<HomeController> logger, DbContextcs.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        } 
        public IActionResult Permission()
        {
            var Roles = _context.Roles.ToList();         //list of objects of Application model
            ViewBag.roles = Roles;

            var Pages = _context.Pages.ToList();
            ViewBag.pages = Pages;

            var permission = _context.RolePagePermissions.ToList();
            ViewBag.permission = permission;


            return View("RolePagePermission");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Permission(RolePagePermission rolePagePermission)
        {
            if (ModelState.IsValid)
            {
                if (rolePagePermission.Id == 0)
                {
                    // Insert new record
                    _context.Add(rolePagePermission);
                }
                else
                {
                    // Update existing record
                    _context.Update(rolePagePermission);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Permission));
            }

            // Repopulate ViewBag if ModelState is invalid
            ViewBag.roles = await _context.Roles.ToListAsync();
            ViewBag.pages = await _context.Pages.ToListAsync();
            ViewBag.permission = await _context.RolePagePermissions.ToListAsync();

            return View("RolePagePermission");
        }

        //NEw WOrk SERCH FOR AJAX/////



        [HttpPost]
        public IActionResult UpdateCanView(IFormCollection fc)
        {
            int id = Convert.ToInt32(fc["id"].ToString());
            bool canView  = Convert.ToBoolean(fc["canView"].ToString());


            var record = _context.RolePagePermissions.FirstOrDefault(r => r.Id == id);
            if (record != null)
            {
                record.CanView = canView;
                record.Updated_at = DateTime.Now; // Update timestamp
                _context.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    
}
