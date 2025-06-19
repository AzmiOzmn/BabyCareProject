using BabyCareProject.Dtos.ProductDtos;

namespace BabyCareProject.Services.ProductSerrvices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllAsync();

        Task<UpdateProductDto> GetById(string id);

        Task CreateAsycn(CreateProductDto createProductDto);

        Task UpdateAsync(UpdateProductDto updateProductDto);

        Task DeleteAsync(string id);


    }
}
