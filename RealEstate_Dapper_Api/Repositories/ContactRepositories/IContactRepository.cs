using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContact(CreateContactDto createContact);
        Task DeleteContact(int id);
        Task<GetByIDContactDto> GetContactAsync(int id);
        Task<List<ResultLast4ContactDto>> GetLast4ContactAsync();
    }
}
