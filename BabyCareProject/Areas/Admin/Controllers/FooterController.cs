using BabyCareProject.Dtos.FooterDtos;
using BabyCareProject.Services.FooterServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCareProject.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class FooterController(IFooterService footerService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await footerService.GetAllAsync();
            return View(values);
        }
        public async Task<IActionResult> CreateFooter()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateFooter(CreateFooterDto createFooterDto)
        {
            await footerService.CreateAsync(createFooterDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await footerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateFooter(string id)
        {
            var values = await footerService.GetByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFooter(UpdateFooterDto updateFooterDto)
        {
            await footerService.UpdateAsync(updateFooterDto);
            return RedirectToAction("Index");
        }
    }
}