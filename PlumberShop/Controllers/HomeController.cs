using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using PlumberShop.Models;

namespace PlumberShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly EfContext _context;
        public HomeController(EfContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //  ViewBag.Test = _context.Goods.Count();
            var posts = _context.Posts.ToList();
            return View(posts);
        }

     
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
