namespace ecommerce.Data.Entity
{
    public class TodoEntity: BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public virtual UserEntity User { get; set; }
    }
}
