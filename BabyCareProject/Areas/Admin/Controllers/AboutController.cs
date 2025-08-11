using BabyCareProject.Dtos.AboutDtos;
using BabyCareProject.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController(IAboutService aboutService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await aboutService.GetAllAboutAsync();
            return View(values);
        }

        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var values = await aboutService.UpdateByIdAsync(id);
            return View(values);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index");
        }
    }
}
