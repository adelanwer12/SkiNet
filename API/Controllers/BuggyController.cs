using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}