using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.ServiceDtos;
using RealEstateDapperApi.Dtos.WhoWeAreDtos;
using RealEstateDapperApi.Repositories.ServiceRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController (IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetServiceList() 
        {
            var value = await _serviceRepository.GetAllServiceAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createService)
        {
            _serviceRepository.CreateService(createService);
            return Ok("Hizmet Kısmı Başarılı Bir Şekilde Eklendi.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            _serviceRepository.DeleteService(id);
            return Ok("Hizmet Kısmı Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            _serviceRepository.UpdateService(updateServiceDto);
            return Ok("Hizmet Kısmı Başarıyla Güncellendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _serviceRepository.GetService(id);
            return Ok(value);
        }


    }
}
