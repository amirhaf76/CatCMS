using CMS.Domain.Entities;
using CMS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.ModelConfigurations
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .HasConversion(pid => pid.Value, id => PostId.Create(id));

            builder
                .Property(p => p.Content)
                .HasMaxLength(-1);
        }
    }
}
