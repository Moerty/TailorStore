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
    public class FabricConfiguration : IEntityTypeConfiguration<Fabric> {
        public void Configure(EntityTypeBuilder<Fabric> builder) {
            builder.HasKey(k => k.Id);

            builder.HasIndex(i => i.Name);

            builder.HasMany(c => c.ClothesFabrics)
                .WithOne(f => f.Fabric)
                .HasForeignKey(k => k.FabricId);
        }
    }
}
