using BabyCareProject.Services.InstructorServices;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController(IInstructorService _instructorService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
