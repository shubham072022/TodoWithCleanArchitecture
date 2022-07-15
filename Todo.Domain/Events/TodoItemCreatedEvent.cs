using Todo.Domain.Common;
using Todo.Domain.Entities;

namespace Todo.Domain.Events
{
    public class TodoItemCreatedEvent : BaseEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }
        public TodoItem Item { get; }
    }
}
