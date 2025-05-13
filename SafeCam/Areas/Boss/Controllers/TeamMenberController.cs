using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeCam.DAL;
using SafeCam.Models;

namespace SafeCam.Areas.Boss.Controllers
{
    [Area("Boss")]
    public class TeamMenberController : Controller
    {
        AppDbContext _context;
        IWebHostEnvironment _env;

        public TeamMenberController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            
            List<Team> teamList = await _context.Teams.ToListAsync();
            return View(teamList);
            
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Team teamVm)
        {
            return RedirectToAction("Index", "Home");
        }





    }
}
