using AutoMapper;
using ecommerce.Core.Base;
using ecommerce.Data.Entity;
using ecommerce.Core.Todo.Dto;
using ecommerce.Source.Core.Todo;
using ecommerce.Source.Core.Todo.Dto;

namespace ecommerce.Core.Todo
{
    public class TodoService : BaseService<TodoEntity, TodoDto, CreateTodoDto, CreateTodoDto>
    {
        public TodoService(TodoDao dao, IMapper mapper) : base(dao, mapper, "Todo")
        {
        }
    }
}
