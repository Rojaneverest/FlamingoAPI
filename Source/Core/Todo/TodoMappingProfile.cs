using ecommerce.Data.Entity;
using ecommerce.Core.Base;
using ecommerce.Core.Todo.Dto;
using ecommerce.Source.Core.Todo.Dto;

namespace ecommerce.Core.Province
{
    public class TodoProfile : BaseMappingProfile<TodoEntity, TodoDto, CreateTodoDto, CreateTodoDto>
    {
        public TodoProfile()
        {
        }
    }
}

