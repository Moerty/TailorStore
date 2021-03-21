using TailorStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace TailorStore.Application.Common.Interfaces {
    public interface IApplicationDbContext {
        DbSet<Domain.Entities.ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Domain.Entities.Clothes> Clothes { get; set; }

        DbSet<Domain.Entities.Fabric> Fabrics { get; set; }
        DbSet<Domain.Entities.ClothesFabric> ClothesFabrics { get; set; }
        DbSet<TailorStore.Domain.Entities.ClothesOption> ClothesOptions { get; set; }
        DbSet<TailorStore.Domain.Entities.Group> Groups { get; set; }

        DbSet<Domain.Entities.Type> Types { get; set; }
        DbSet<Domain.Entities.Option> Options { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
