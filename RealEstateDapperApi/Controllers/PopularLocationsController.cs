using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.PopularLocationDtos;
using RealEstateDapperApi.Repositories.PopularLocationRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _popularLocationRepository;

        public PopularLocationsController(IPopularLocationRepository popularLocationRepository)
        {
            _popularLocationRepository = popularLocationRepository;
        }


        [HttpGet]

        public async Task<IActionResult> PopularLocationList()
        {
            var value = await _popularLocationRepository.GetAllPopularLocationAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocation)
        {
            _popularLocationRepository.CreatePopularLocation(createPopularLocation);
            return Ok("Lokasyon Kısmı Başarılı Bir Şekilde Eklendi.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            _popularLocationRepository.DeletePopularLocation(id);
            return Ok("Lokasyon Kısmı Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            _popularLocationRepository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok("Lokasyon Kısmı Başarıyla Güncellendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var value = await _popularLocationRepository.GetPopularLocation(id);
            return Ok(value);
        }

    }
}
