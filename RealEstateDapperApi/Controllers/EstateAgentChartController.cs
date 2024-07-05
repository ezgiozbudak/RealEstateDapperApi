using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentChartController : ControllerBase
    {
        private readonly IChartRepository _chartRepository;

        public EstateAgentChartController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetChart5()
        {
            return Ok(await _chartRepository.Get5CityForChart());
        }
    }
}
