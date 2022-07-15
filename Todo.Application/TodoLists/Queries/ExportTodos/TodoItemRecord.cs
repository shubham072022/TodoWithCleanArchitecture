using Todo.Application.Common.Mappings;
using Todo.Domain.Entities;

namespace Todo.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string? Title { get; set; }

        public bool Done { get; set; }
    }
}
