using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address, DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay='False' where ProductID=@productID";
            var parameters = new DynamicParameters();

            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay='True' where ProductID=@productID";
            var parameters = new DynamicParameters();
            
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            //string query = "Update Product Set Name=@name, Title= @title, Mail=@mail, PhoneNumber=@phoneNumber, ImageUrl= @imageUrl, Status= @status where EmployeeID=@employeeID";
            //var parameters = new DynamicParameters();
            //parameters.Add("@name", updateProductDto.);
            //parameters.Add("@title", updateProductDto.Title);
            //parameters.Add("@mail", updateProductDto.Mail);
            //parameters.Add("@phoneNumber", updateProductDto.PhoneNumber);
            //parameters.Add("@imageUrl", updateProductDto.ImageUrl);
            //parameters.Add("@status", updateProductDto.Status);
            //parameters.Add("@employeeID", updateProductDto.EmployeeID);
            //using (var connection = _context.CreateConnection())
            //{
            //    await connection.ExecuteAsync(query, parameters);
            //}
            throw new NotImplementedException();

        }
    }
}
