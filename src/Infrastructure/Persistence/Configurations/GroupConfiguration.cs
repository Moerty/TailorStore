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
    public class GroupConfiguration : IEntityTypeConfiguration<Group> {
        public void Configure(EntityTypeBuilder<Group> builder) {
            builder.HasKey(k => k.Id);

            builder.HasMany(c => c.Clothes)
                .WithOne(o => o.Group)
                .HasForeignKey(k => k.GroupId);
        }
    }
}
