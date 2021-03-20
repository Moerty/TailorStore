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
    public class OptionConfiguration : IEntityTypeConfiguration<Option> {
        public void Configure(EntityTypeBuilder<Option> builder) {
            builder.HasKey(k => k.Id);

            builder.HasOne(t => t.Type)
                .WithMany(o => o.Options)
                .HasForeignKey(k => k.TypeId);
        }
    }
}
