using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
        Task CreateEmployee(CreateEmployeeDto createEmployee);
        Task DeleteEmployee(int id);
        Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        Task<GetByIDEmployeeDto> GetEmployeeAsync(int id);

    }
}
