using CMSRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSRepository
{
    public class CMSDBContext : DbContext
    {
        public CMSDBContext(DbContextOptions<CMSDBContext> options) : base(options)
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
            HostModelCreation(modelBuilder);

            UserModelCreation(modelBuilder);
        }



        private static void UserModelCreation(ModelBuilder modelBuilder)
        {
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

        private static void HostModelCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Host>(buildAction =>
            {
                buildAction.HasKey(h => h.Id);

            });
        }
    }
}
