using Todo.Application.Common.Mappings;
using Todo.Domain.Entities;

namespace Todo.Application.TodoItems.Queries.GetTodoItemsWithPagination
{
    public class TodoItemBriefDto : IMapFrom<TodoItem>
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public string? Title { get; set; }

        public bool Done { get; set; }
    }
}
