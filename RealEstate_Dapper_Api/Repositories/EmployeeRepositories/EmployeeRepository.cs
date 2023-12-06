﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateEmployee(CreateEmployeeDto createEmployee)
        {
            string query = "insert into Employee (Name, Title, Mail, PhoneNumber, ImageUrl, Status ) values (@name , @title, @mail, @phoneNumber, @imageUrl, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createEmployee.Name);
            parameters.Add("@title", createEmployee.Title);
            parameters.Add("@mail", createEmployee.Mail);
            parameters.Add("@phoneNumber", createEmployee.PhoneNumber);
            parameters.Add("@imageUrl", createEmployee.ImageUrl);
            parameters.Add("@status", true);
            
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            string query = "Delete From Employee Where EmployeeID = @employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployeeAsync(int id)
        {
            string query = "Select * From Employee where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parameters);
                return value;
            }
        }

        public async Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "Update Employee Set Name=@name, Title= @title, Mail=@mail, PhoneNumber=@phoneNumber, ImageUrl= @imageUrl, Status= @status where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateEmployeeDto.Name);
            parameters.Add("@title", updateEmployeeDto.Title);
            parameters.Add("@mail", updateEmployeeDto.Mail);
            parameters.Add("@phoneNumber", updateEmployeeDto.PhoneNumber);
            parameters.Add("@imageUrl", updateEmployeeDto.ImageUrl);
            parameters.Add("@status", updateEmployeeDto.Status);
            parameters.Add("@employeeID", updateEmployeeDto.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
