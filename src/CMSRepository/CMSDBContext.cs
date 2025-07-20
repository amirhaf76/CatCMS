using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSRepository
{
    public class CMSDBContext : DbContext
    {
        public CMSDBContext(DbContextOptions<CMSDBContext>options) : base(options)
        {
                
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<string>()
                .AreUnicode()
                .HaveMaxLength(150);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Host>(buildAction =>
            {
                buildAction.HasKey(h => h.Id);

            });

            modelBuilder.Entity<User>(buildAction =>
            {
                buildAction.HasKey(u => u.Id);

                buildAction
                    .Property(u => u.Status)
                    .HasConversion<string>()
                    .HasMaxLength(150);

                buildAction
                    .HasMany(u => u.Hosts)
                    .WithOne(h => h.Creator)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
