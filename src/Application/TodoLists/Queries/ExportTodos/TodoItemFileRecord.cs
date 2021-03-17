using TailorStore.Application.Common.Mappings;
using TailorStore.Domain.Entities;

namespace TailorStore.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
