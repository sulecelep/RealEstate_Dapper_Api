using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto createCategory)
        {
            string query = "insert into Category (CategoryName, CategoryStatus) values (@categoryName , @categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", createCategory.CategoryName);
            parameters.Add("@categoryStatus", true);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID = @categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDCategoryDto> GetCategoryAsync(int id)
        {
            string query = "Select * From Category where CategoryID=@CategoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, parameters);
                return value;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName, CategoryStatus= @categoryStatus where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", updateCategoryDto.CategoryName);
            parameters.Add("@categoryStatus", updateCategoryDto.CategoryStatus);
            parameters.Add("@categoryID", updateCategoryDto.CategoryID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
