using TailorStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace TailorStore.Application.Common.Interfaces {
    public interface IApplicationDbContext {
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Clothes> Clothes { get; set; }

        DbSet<Fabric> Fabrics { get; set; }
        DbSet<ClothesFabric> ClothesFabrics { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
