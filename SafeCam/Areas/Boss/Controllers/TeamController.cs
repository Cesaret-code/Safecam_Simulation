using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeCam.Areas.Boss.ViewModel.TeamMenber;
using SafeCam.DAL;
using SafeCam.Models;

namespace SafeCam.Areas.Boss.Controllers
{
    [Area("Boss")]
    public class TeamController : Controller
    {
        AppDbContext _context;
        IWebHostEnvironment _env;

        public TeamController(AppDbContext context, IWebHostEnvironment env)
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
        public async Task<IActionResult> Create(TeamMenberVm teamMenberVm)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (teamMenberVm.File.ContentType.Contains("image"))
            {
                ModelState.AddModelError("File", "Duzgun format daxil edin");
                return View();
            }

            if(teamMenberVm.File.Length >= 2097152)
            {
                ModelState.AddModelError("File", "File olcusu boyukdur");
                return View();
            }

            //teamMenberVm.ImgUrl = teamMenberVm.File.CreateFile(_env.WebRootPath, "Upload/TeamMembers");

            Team team = new Team()
            {
                Fullname = teamMenberVm.FullName,
                Designation = teamMenberVm.Designation,
                ImgUrl = teamMenberVm.ImgUrl,
                //File = teamMenberVm.File

            };

            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }

            var member = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);

            if(member==null)
            {
                return NotFound();
            }

            //member.ImgUrl.RemoveFile(_env.WebRootPath, "Upload/Teams");

            _context.Teams.Remove(member);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        //Update qalib

    }
}
