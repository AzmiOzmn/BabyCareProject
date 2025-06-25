using BabyCareProject.Dtos.NavbarDtos;
using BabyCareProject.Services.NavbarServices;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NavbarController : Controller
    {
        private readonly INavbarService _navbarService;

        public NavbarController(INavbarService navbarService)
        {
            _navbarService = navbarService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _navbarService.GetAllAsync();
            return View(values);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNavbarDto createNavbarDto)
        {
            await _navbarService.CreateAsync(createNavbarDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _navbarService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(string id)
        {
            var values = await _navbarService.GetByIdAsync(id);
            return View(values);
        }

        [HttpPost]

        public async Task<IActionResult> Update(UpdateNavbarDto updateNavbarDto)
        {
            await _navbarService.UpdateAsync(updateNavbarDto);
            return RedirectToAction("Index");
        }
    }
}
