using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoListAsync();
        Task CreateToDoList(CreateToDoListDto createToDoList);
        Task DeleteToDoList(int id);
        Task UpdateToDoList(UpdateToDoListDto updateToDoListDto);
        Task<GetByIDToDoListDto> GetToDoListAsync(int id);
    }
}
