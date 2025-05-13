using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeCam.DAL;
using SafeCam.Models;
using SafeCam.ViewModels.Home;

namespace SafeCam.Controllers
{
    public class HomeController : Controller
    {

        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Team> teamList = await _context.Teams.ToListAsync();

            //HomeVm homeVm = new HomeVm()
            //{
            //    Team = teamList,
            //};
            return View();
        }

        


    }
}
