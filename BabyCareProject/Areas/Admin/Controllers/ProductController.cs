using BabyCareProject.Dtos.ProductDtos;
using BabyCareProject.Services.InstructorServices;
using BabyCareProject.Services.ProductSerrvices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Driver;

namespace BabyCareProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IProductService productService, IInstructorService instructorService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await productService.GetAllAsync();
            return View(values);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateProduct()
        {
            var instructors = await instructorService.GetAllInstructorAsync();
            ViewBag.instructors = (from x in instructors
                                   select new SelectListItem
                                   {
                                       Text = x.FullName,
                                       Value = x.FullName
                                   }).ToList();
            return View();


        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
           
            var instructor = (await instructorService.GetAllInstructorAsync())
                .FirstOrDefault(x => x.FullName == createProductDto.InstructorName);

            if (instructor != null)
            {
                createProductDto.InstructorImage = instructor.ImageUrl;
                createProductDto.InstructorTitle = instructor.Title;
            }

            await productService.CreateAsycn(createProductDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(string id)
        {
            var instructors = await instructorService.GetAllInstructorAsync();
            ViewBag.instructors = (from x in instructors
                                   select new SelectListItem
                                   {
                                       Text = x.FullName,
                                       Value = x.FullName
                                   }).ToList();


            var value = await productService.GetById(id);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var instructor = (await instructorService.GetAllInstructorAsync())
                .FirstOrDefault(x => x.FullName == updateProductDto.InstructorName);

            if (instructor != null)
            {
                updateProductDto.InstructorImage = instructor.ImageUrl;
                updateProductDto.InstructorTitle = instructor.Title;
            }

            await productService.UpdateAsync(updateProductDto);
            return RedirectToAction(nameof(Index));
        }



    }
}