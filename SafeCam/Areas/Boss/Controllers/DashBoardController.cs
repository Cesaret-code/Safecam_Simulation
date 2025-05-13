using Microsoft.AspNetCore.Mvc;

namespace SafeCam.Areas.Boss.Controllers
{
    [Area("Boss")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
