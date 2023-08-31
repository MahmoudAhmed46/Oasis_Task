using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OasisTask.BL.Contract;
using OasisTask.BL.DTOs;
using OasisTask.BL.Models;
using OasisTask.BL.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OasisTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ToDoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IToDoService _TodoService;

        public ToDoController(IUnitOfWork unitOfWork, IMapper mapper, IToDoService TodoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _TodoService = TodoService;
        }
        [HttpGet("GetAllPagination")]
        public async Task<IActionResult> GetAll([FromQuery] int start, [FromQuery] int limit)
        {
            
            var todoList = (await _TodoService.GetToDoPagination(start, limit)).ToList();
            if (todoList.Count() > 0)
            {
                return Ok(todoList);
            }    
            return StatusCode(StatusCodes.Status204NoContent, new Response { Status = "Warning", Message = "No Item Found" });
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ToDoDto toDoDto)
        {
            string errors = string.Empty;

            if (ModelState.IsValid)
            {
                ToDo todo = _mapper.Map<ToDo>(toDoDto);
                var result = await _unitOfWork.ToDos.CreateAsync(todo);
                if (result != null)
                {
                    int count = await _unitOfWork.SaveChangesAsync();
                    return Ok(new Response { Status = "Success", Message = "ToDo Created Successfully" });
                }
            }
            else
            {
                errors = CheckModelStateError(ModelState);
            }

            return BadRequest(new Response{ Status="Faild",Message=errors });

        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _unitOfWork.ToDos.GetByIdAsync(id);
            if (todo != null)
            {
                return Ok(todo);
            }
            return BadRequest(new Response { Status = "Error", Message = $"Todo Not Found with Id: {id}" });
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] ToDoDto todoDto)
        {
            string errors = string.Empty;

            if (ModelState.IsValid)
            {
                ToDo oldTodo = await _unitOfWork.ToDos.GetByIdAsync(id);
                if (oldTodo != null)
                {
                    try
                    {
                        ToDo todo = _mapper.Map<ToDo>(todoDto);
                        todo.id = id;
                        var Todoitem =await _unitOfWork.ToDos.UpdateAsync(todo);
                        await _unitOfWork.SaveChangesAsync();
                        return Ok(Todoitem);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(new Response { Status = "Faild", Message = $"Faild To Update Todo With id: {id}" });

                    }
                }
                errors += $"Todo with id: {id} Not Found";
            }
            else
            {
                errors = CheckModelStateError(ModelState);
            }

            return BadRequest(new Response { Status = "Faild", Message = errors });

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool res = await _unitOfWork.ToDos.DeleteAsync(id);
                if (res)
                {
                    await _unitOfWork.SaveChangesAsync();
                    return StatusCode(StatusCodes.Status200OK, new Response
                    {
                        Status = "Success",
                        Message = "Todo Deleted Successfully"
                    });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new Response 
                { 
                  Status = "Faild", 
                  Message = $"Faild To Delete Todo With id: {id}" 
                });

            }
            return BadRequest(new Response { Status = "Faild", Message = $"Todo With id: {id} Not Found" });
        }
        private string CheckModelStateError(ModelStateDictionary ModelState)
        {
            string errors = string.Empty;
            foreach (var modelStateEntry in ModelState)
            {
                var errorMessages = modelStateEntry.Value.Errors.Select(e => e.ErrorMessage);
                foreach (string error in errorMessages)
                {
                    errors += error;
                }
            }
            return errors;
        }
    }
}
