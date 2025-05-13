using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeCam.DAL;
using SafeCam.Models;

namespace SafeCam.Controllers
{
    public class TeamController : Controller
    {



        AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
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

    }
}
