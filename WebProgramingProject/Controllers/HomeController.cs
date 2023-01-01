using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebProgramingProject.Data;
using WebProgramingProject.Models;

namespace WebProgramingProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            int movieCount = _context.Movie.Count();

            var totalmovie = _context.Movie.Include(x => x.Categories).ThenInclude(mp => mp.Category).ToList();
            var slidermovie = _context.Movie.Take(5).Include(x => x.Categories).ThenInclude(mp => mp.Category).ToList();
            var trendmovie = _context.Movie.Take(5).Include(x => x.Categories).ThenInclude(mp => mp.Category).ToList();

            HomeViewModel homeview = new HomeViewModel(totalmovie, trendmovie, slidermovie, "Yeni Çıkanlar");
            return View(homeview);
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }




       
    }
}