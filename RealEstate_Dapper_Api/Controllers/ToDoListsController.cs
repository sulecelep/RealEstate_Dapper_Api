using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListsController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ToDoListList()
        {
            var values = await _toDoListRepository.GetAllToDoListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            await _toDoListRepository.CreateToDoList(createToDoListDto);
            return Ok("To Do Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            await _toDoListRepository.DeleteToDoList(id);
            return Ok("To Do Başarılı Bir Şekilde Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            await _toDoListRepository.UpdateToDoList(updateToDoListDto);
            return Ok("To Do Başarılı Bir Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoList(int id)
        {
            var value = await _toDoListRepository.GetToDoListAsync(id);
            return Ok(value);
        }
    }
}
