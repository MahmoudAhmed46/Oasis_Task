using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OasisTask.BL.Contract;
using OasisTask.BL.Models;

namespace OasisTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveToDoController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;

        public LiveToDoController(IHttpClientFactory httpClientFactory, IUnitOfWork unitOfWork)
        {
            _httpClientFactory = httpClientFactory;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("ReadToDo")]
        public async Task<IActionResult> ReadAll()
        {
            string apiURI = "https://jsonplaceholder.typicode.com/todos";
            HttpClient httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<List<ToDo>>(apiURI);
            if(response.Count()>0)
            {
                //uncomment this lines to insert fetch todo data one time

                //var todoList = _unitOfWork.ToDos.InsertRangeAsync(response);
                //await _unitOfWork.SaveChangesAsync();
                //return Ok(todoList);

                return Ok(response);
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "Error on Read ToDo Data" });
        }
    }
}
