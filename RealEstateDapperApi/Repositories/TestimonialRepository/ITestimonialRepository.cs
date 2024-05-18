using RealEstateDapperApi.Dtos.TestimonialDtos;

namespace RealEstateDapperApi.Repositories.TestimonialRepository
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
    }
}
