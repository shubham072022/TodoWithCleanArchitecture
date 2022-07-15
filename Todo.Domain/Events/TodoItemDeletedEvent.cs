using Todo.Domain.Common;
using Todo.Domain.Entities;

namespace Todo.Domain.Events
{
    public class TodoItemDeletedEvent : BaseEvent
    {
        public TodoItemDeletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
