using RealEstateDapperApi.Dtos.BottomGridDtos;

namespace RealEstateDapperApi.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDto bottomGridDto);
        void DeleteBottomGrid(int id);
        void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto);
        Task<GetBottomGridDto> GetBottomGrid(int id);
    }
}
