using ecommerce.Core.Base;
using ecommerce.Core.Province.Dto;
using ecommerce.Core.Province;
using ecommerce.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Core.Todo.Dto;
using ecommerce.Source.Core.Todo.Dto;

namespace ecommerce.Core.Todo
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : BaseController<TodoEntity, TodoDto, CreateTodoDto, CreateTodoDto>
    {
        public TodoController(TodoService service) : base(service, "Todo")
        {
        }
    }
}
