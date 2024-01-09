
using Dapper;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateToDoList(CreateToDoListDto createToDoList)
        {
            string query = "insert into ToDoList (Description, ToDoListStatus ) values (@description , @toDoListStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@description", createToDoList.Description);
            parameters.Add("@toDoListStatus", createToDoList.ToDoListStatus);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteToDoList(int id)
        {
            string query = "Delete From ToDoList Where ToDoListID = @toDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@toDoListID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
        {
            string query = "Select * From ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDToDoListDto> GetToDoListAsync(int id)
        {
            string query = "Select * From ToDoList where ToDoListID=@toDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@toDoListID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIDToDoListDto>(query, parameters);
                return value;
            }
        }

        public async Task UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            string query = "Update Employee Set Description=@description , ToDoListStatus=@toDoListStatus where ToDoListID=@toDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@description", updateToDoListDto.Description);
            parameters.Add("@toDoListStatus", updateToDoListDto.ToDoListStatus);
            parameters.Add("@toDoListID", updateToDoListDto.ToDoListID);


            parameters.Add("@toDoListID", updateToDoListDto.ToDoListID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
