using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Domain.Entities;

namespace TailorStore.Infrastructure.Persistence.Configurations
{
    public class ClothesFabricConfiguration : IEntityTypeConfiguration<ClothesFabric> {
        public void Configure(EntityTypeBuilder<ClothesFabric> builder) {
            builder.HasKey(k => k.Id);

            builder.HasIndex(i => new { i.FabricId, i.ClothesId });

            builder.HasOne(f => f.Fabric)
                .WithMany(c => c.ClothesFabrics)
                .HasForeignKey(k => k.FabricId);

            builder.HasOne(f => f.Clothes)
                .WithMany(c => c.ClothesFabrics)
                .HasForeignKey(k => k.ClothesId);
        }
    }
}
