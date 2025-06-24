using AutoMapper;
using BabyCareProject.Dtos.ProductDtos;
using BabyCareProject.Services.ProductSerrvices;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.ViewComponents.Default
{
    public class _DefaultProgramsComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public _DefaultProgramsComponent(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllAsync();
            var programs = _mapper.Map<List<ResultProductDto>>(values);
            return View(programs);
        }
    }
}
