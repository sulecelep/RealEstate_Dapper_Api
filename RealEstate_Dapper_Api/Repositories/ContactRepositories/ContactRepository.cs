using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateContact(CreateContactDto createContact)
        {
            string query = "insert into Contact (Name, Subject, Email, Message, SendDate ) values (@name , @subject, @email, @message, @sendDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createContact.Name);
            parameters.Add("@subject", createContact.Subject);
            parameters.Add("@email", createContact.Email);
            parameters.Add("@message", createContact.Message);
            parameters.Add("@sendDate", createContact.SendDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteContact(int id)
        {
            string query = "Delete From Contact Where ContactID = @contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@contactID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            string query = "Select * From Contact";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDContactDto> GetContactAsync(int id)
        {
            string query = "Select * From Contact where ContactID = @contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@contactID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIDContactDto>(query, parameters);
                return value;
            }
        }

        public async Task<List<ResultLast4ContactDto>> GetLast4ContactAsync()
        {
            string query = "Select Top(4) * From Contact order by ContactID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast4ContactDto>(query);
                return values.ToList();
            }
        }
    }
}
