using TailorStore.Domain.Common;
using TailorStore.Domain.Entities;

namespace TailorStore.Domain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
