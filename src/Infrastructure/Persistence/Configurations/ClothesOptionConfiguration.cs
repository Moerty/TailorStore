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
    public class ClothesOptionConfiguration : IEntityTypeConfiguration<ClothesOption> {
        public void Configure(EntityTypeBuilder<ClothesOption> builder) {
            builder.HasKey(k => k.Id);

            builder.HasOne(o => o.Clothes)
                .WithMany(o => o.ClothesOptions)
                .HasForeignKey(k => k.ClothesId);

            builder.HasOne(o => o.Option)
                .WithMany(o => o.ClothesOptions)
                .HasForeignKey(k => k.OptionId);
        }
    }
}
