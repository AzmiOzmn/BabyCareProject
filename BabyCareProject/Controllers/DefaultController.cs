using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
