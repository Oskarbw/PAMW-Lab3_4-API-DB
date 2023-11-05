using Microsoft.EntityFrameworkCore;

namespace PAMW3_API
{
    public class PostOfficeContext : DbContext
    {
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Carrier> Carriers { get; set; }

        public PostOfficeContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\DbPostOffice");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parcel>(eb =>
            {
                eb.HasKey(p => p.Id);
                eb.Property(p => p.Sender).HasColumnType("varchar(50)");
                eb.Property(p => p.Receiver).HasColumnType("varchar(50)").IsRequired();
                eb.HasOne(p => p.Carrier)
                .WithMany(c => c.Parcels)
                .HasForeignKey(p => p.CarrierId);
            });
            modelBuilder.Entity<Carrier>(eb =>
            {
                eb.HasKey(c => c.Id);
                eb.Property(c => c.Name).HasColumnType("varchar(50)");
            });
        }

    }
}
