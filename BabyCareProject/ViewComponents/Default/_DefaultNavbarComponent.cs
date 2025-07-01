using AutoMapper;
using BabyCareProject.Dtos.NavbarDtos;
using BabyCareProject.Services.NavbarServices;
using Microsoft.AspNetCore.Mvc;

public class _DefaultNavbarComponent : ViewComponent
{
    private readonly IMapper mapper;
    private readonly INavbarService navbarService;

    public _DefaultNavbarComponent(IMapper mapper, INavbarService navbarService)
    {
        this.mapper = mapper;
        this.navbarService = navbarService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await navbarService.GetAllAsync();
        var dto = mapper.Map<List<ResultNavbarDto>>(values);
        return View(dto);
    }
}
