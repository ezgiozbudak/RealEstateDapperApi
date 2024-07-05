using RealEstateDapperApi.Dtos.ChartDtos;

namespace RealEstateDapperApi.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public interface IChartRepository
    {
       Task<List<ResultChartDto>> Get5CityForChart();
    }
}
