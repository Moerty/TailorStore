using TailorStore.Domain.Common;
using System.Threading.Tasks;

namespace TailorStore.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
