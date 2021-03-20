using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorStore.Infrastructure.Persistence.Configurations {
    public class TypeConfiguration : IEntityTypeConfiguration<Domain.Entities.Type> {
        public void Configure(EntityTypeBuilder<Domain.Entities.Type> builder) {
            builder.HasKey(k => k.Id);

            builder.HasIndex(i => i.Name);

            builder.HasMany(o => o.Options)
                .WithOne(t => t.Type)
                .HasForeignKey(k => k.TypeId);
        }
    }
}
