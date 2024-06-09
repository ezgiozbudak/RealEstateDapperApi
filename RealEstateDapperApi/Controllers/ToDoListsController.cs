using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Repositories.ToDoListRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListsController(IToDoListRepository ToDoListRepository)
        {
            _toDoListRepository = ToDoListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ToDoListList()
        {
            var values = await _toDoListRepository.GetAllToDoListAsync();
            return Ok(values);
        }
    }
}
