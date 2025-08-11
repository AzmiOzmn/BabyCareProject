using BabyCareProject.Dtos.EventDtos;
using BabyCareProject.Services.EventServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController(IEventService eventService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await eventService.GetAllAsync();
            return View(values);
        }

        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDto createEventDto)
        {
            await eventService.CreateAsync(createEventDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await eventService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateEvent(string id)
        {
            var values = await eventService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEvent(UpdateEventDto updateEventDto)
        {
            await eventService.UpdateAsync(updateEventDto);
            return RedirectToAction("Index");
        }
    }
}