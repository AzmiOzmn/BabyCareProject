using AutoMapper;
using BabyCareProject.DataAccess.Entities;
using BabyCareProject.DataAccess.Settings;
using BabyCareProject.Dtos.TestimonialDtos;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BabyCareProject.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Testimonial> _testimonialCollection;

        public TestimonialService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _testimonialCollection = mongoDatabase.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);

        }
        public Task CreateAsync(CreateTestimonialDto createTestimonialDto)
        {
            var values = _mapper.Map<Testimonial>(createTestimonialDto);
            return _testimonialCollection.InsertOneAsync(values);
        }

        public async Task DeleteAsync(string id)
        {
            await _testimonialCollection.DeleteOneAsync(x => x.TestimonialId == id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllAsync()
        {
            var values = await _testimonialCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(values);
        }

        public async Task<UpdateTestimonialDto> GetByIdAsync(string id)
        {
            var value = await _testimonialCollection.Find(x => x.TestimonialId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateTestimonialDto>(value);
        }

        public Task UpdateAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            return _testimonialCollection.FindOneAndReplaceAsync(x => x.TestimonialId == testimonial.TestimonialId, testimonial);
        }
    }
}
