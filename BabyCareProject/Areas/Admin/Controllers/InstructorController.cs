using BabyCareProject.Dtos.InstructorDtos;
using BabyCareProject.Services.InstructorServices;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController(IInstructorService _instructorService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _instructorService.GetAllInstructorAsync();
            return View(values);
        }
        public async Task<IActionResult> CreateInstructor()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateInstructor(CreateInstructorDto dto)
        {
            await _instructorService.CreateInstructorAsync(dto);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(string id)
        {
            await _instructorService.DeleteInstructorAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateInstructor(string id)
        {
            var values = await _instructorService.GetInstructorByIdAsync(id);
            return View(values);
        }

        [HttpPost]

        public async Task<IActionResult> UpdateInstructor(UpdateInstructorDto dto)
        {
            await _instructorService.UpdateInstructorAsync(dto);
            return RedirectToAction("Index");

        }
    }
}