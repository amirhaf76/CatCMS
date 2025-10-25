using CMS.Domain.Entities;
using CMS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.ModelConfigurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .HasConversion(pd => pd.Value, id => PermissionId.Create(id));

        }
    }
}
