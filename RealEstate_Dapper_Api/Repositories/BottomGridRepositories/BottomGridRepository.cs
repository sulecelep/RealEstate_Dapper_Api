using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateBottomGrid(CreateBottomGridDto createBottomGrid)
        {
            string query = "insert into BottomGrid (Title, Description, Icon) values (@title , @description, @icon)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createBottomGrid.Title);
            parameters.Add("@description", createBottomGrid.Description);
            parameters.Add("@icon", createBottomGrid.Icon);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteBottomGrid(int id)
        {
            throw new NotImplementedException();
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

        public async Task<GetByIDBottomGridDto> GetBottomGridAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            throw new NotImplementedException();
        }
    }
}
