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
    public class ClothesConfiguration : IEntityTypeConfiguration<Clothes> {
        public void Configure(EntityTypeBuilder<Clothes> builder) {
            builder.HasKey(k => k.Id);

            builder.HasIndex(i => i.Name);

            builder.HasOne(u => u.ApplicationUser)
                .WithMany(c => c.Clothes)
                .HasForeignKey(k => k.ApplicationUserId);
        }
    }
}
