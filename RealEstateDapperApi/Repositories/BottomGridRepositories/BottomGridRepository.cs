using Dapper;
using RealEstateDapperApi.Dtos.BottomGridDtos;
using RealEstateDapperApi.Dtos.ServiceDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;
        public BottomGridRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }

        }

        public async void CreateBottomGrid(CreateBottomGridDto bottomGridDto)
        {
            string query = "insert into BottomGrid (Icon, Title,Description) values (@icon,@title,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", bottomGridDto.Icon);
            parameters.Add("@title", bottomGridDto.Title);
            parameters.Add("@description", bottomGridDto.Description);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "Delete From BottomGrid Where BottomGridID= @bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetBottomGridDto> GetBottomGrid(int id)
        {
            string query = "Select * From BottomGrid Where BottomGridID = @bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
        {
            string query = "Update BottomGrid Set Icon=@icon,Title = @title,Description=@description  where BottomGridID=@bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", bottomGridDto.Icon);
            parameters.Add("@title", bottomGridDto.Title);
            parameters.Add("@description", bottomGridDto.Description);
            parameters.Add("@bottomGridID", bottomGridDto.BottomGridId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
