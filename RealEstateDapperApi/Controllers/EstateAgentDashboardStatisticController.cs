using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public EstateAgentDashboardStatisticController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("ProductCountByEmployeeId")]
        public ActionResult ProductCountByEmployeeId(int id)
        {
            return Ok(_statisticRepository.ProductCountByEmployeeId(id));
        }

        [HttpGet("ProductCountByStatusTrue")]
        public ActionResult ProductCountByStatusTrue(int id)
        {
            return Ok(_statisticRepository.ProductCountByStatusTrue(id));
        }

        [HttpGet("ProductCountByStatusFalse")]
        public ActionResult ProductCountByStatusFalse(int id)
        {
            return Ok(_statisticRepository.ProductCountByStatusFalse(id));
        }

        [HttpGet("AllProductCount")]
        public ActionResult AllProductCount()
        {
            return Ok(_statisticRepository.AllProductCount());
        }
    }
}
