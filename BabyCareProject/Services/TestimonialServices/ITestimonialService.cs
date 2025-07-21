using BabyCareProject.Dtos.TestimonialDtos;

namespace BabyCareProject.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllAsync();
        Task<UpdateTestimonialDto> GetByIdAsync(string id);
        Task CreateAsync(CreateTestimonialDto createTestimonialDto);
        Task DeleteAsync(string id);
        Task UpdateAsync(UpdateTestimonialDto updateTestimonialDto);
    }
}
