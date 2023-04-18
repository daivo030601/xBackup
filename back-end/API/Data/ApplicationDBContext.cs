using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace back_end.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<Server> servers { get; set; }
        public DbSet<Authentication> authentications { get; set; }
        public DbSet<General> generals { get; set; }
        public DbSet<Proxy> proxys { get; set; }
        public DbSet<FileDetails> fileDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Server>().HasKey(x => x.Id);
            modelBuilder.Entity<Authentication>().HasKey(x => x.Id);
            modelBuilder.Entity<General>().HasKey(x => x.Id);
            modelBuilder.Entity<Proxy>().HasKey(x => x.Id);
            modelBuilder.Entity<FileDetails>().HasKey(x => x.Id);

            modelBuilder.Entity<Server>(e =>
            {
            });

            modelBuilder.Entity<Authentication>(e =>
            {
                e.Property(en => en.AuthDatabase).IsRequired(false);
                e.Property(en => en.Password).IsRequired(false);
                e.Property(en => en.Username).IsRequired(false);
            });

            modelBuilder.Entity<General>(e =>
            {
                e.Property(en => en.Host).IsRequired(false);
            });

            modelBuilder.Entity<Proxy>(e =>
            {
                e.Property(en => en.SshPassword).IsRequired(false);
                e.Property(en => en.HostName).IsRequired(false);
                e.Property(en => en.SshUserName).IsRequired(false);
            });

            modelBuilder.Entity<Server>()
               .HasOne<General>(s => s.General)
               .WithOne(g => g.Server)
               .HasForeignKey<General>(g => g.ServerId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Server>()
               .HasOne<Authentication>(s => s.Authentication)
               .WithOne(au => au.Server)
               .HasForeignKey<Authentication>(au => au.ServerId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Server>()
               .HasOne<Proxy>(s => s.Proxy)
               .WithOne(p => p.Server)
               .HasForeignKey<Proxy>(p => p.ServerId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Proxy>()
               .HasOne<FileDetails>(p => p.IdentityFile)
               .WithOne(f => f.Proxy)
               .HasForeignKey<FileDetails>(ad => ad.ProxyId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
