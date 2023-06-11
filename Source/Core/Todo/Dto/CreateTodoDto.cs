namespace ecommerce.Core.Todo.Dto
{
    public class CreateTodoDto
    { 
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
}
}
