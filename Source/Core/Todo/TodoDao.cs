using ecommerce.Core.Base;
using ecommerce.Data.Entity;
using ecommerce.Data;

namespace ecommerce.Source.Core.Todo
{
    public class TodoDao : BaseDao<TodoEntity>
    {
        public TodoDao(DatabaseContext context) : base(context)
        {
        }
    }
}
