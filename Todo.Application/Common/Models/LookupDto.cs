using Todo.Application.Common.Mappings;
using Todo.Domain.Entities;

namespace Todo.Application.Common.Models
{
    public class LookupDto : IMapFrom<TodoList>, IMapFrom<TodoItem>
    {
        public int Id { get; set; }

        public string? Title { get; set; }
    }
}
