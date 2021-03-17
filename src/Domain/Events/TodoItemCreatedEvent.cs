using TailorStore.Domain.Common;
using TailorStore.Domain.Entities;

namespace TailorStore.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
