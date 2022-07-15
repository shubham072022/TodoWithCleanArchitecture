using Todo.Application.TodoLists.Queries.ExportTodos;

namespace Todo.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
