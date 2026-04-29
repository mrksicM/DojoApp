using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DojoDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Dojo> Dojos { get; set; }
        public DbSet<AikidoEvent> AikidoEvents { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        //public DbSet<Note> Notes { get; set; }

        public DojoDbContext(DbContextOptions<DojoDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Member
            modelBuilder.Entity<Member>(builder =>
            {
                // Global query filter for logical deletion
                builder.HasQueryFilter(m => m.IsActive);

                // Name as an owned type
                builder.OwnsOne(m => m.Name);

                // PersonalInfo as an owned type
                builder.OwnsOne(m => m.PersonalInfo, pi =>
                {
                    pi.OwnsOne(p => p.Address);
                    pi.OwnsOne(p => p.Contact);
                    pi.OwnsOne(p => p.ParentName);
                });

                // TraineeInfo as an owned type
                builder.OwnsOne(m => m.TraineeInfo, ti =>
                {
                    // Notes as owned collection
                    ti.OwnsMany(t => t.Notes);
                });
            });

            // Dojo
            modelBuilder.Entity<Dojo>(builder =>
            {
                builder.Property(d => d.Name).IsRequired();
                builder.OwnsOne(d => d.Contact);
                builder.OwnsOne(d => d.Address);

                // DojoCho relationship
                builder.HasOne(d => d.DojoCho)
                    .WithMany()                          // a Member can be dojo-cho of multiple dojos
                    .HasForeignKey(d => d.DojoChoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // AikidoEvent
            modelBuilder.Entity<AikidoEvent>(builder =>
            {
                // Many-to-many join table for attendees
                // builder.HasMany<Member>()
                //        .WithMany()
                //        .UsingEntity<Dictionary<string, object>>(
                //            "EventAttendees",
                //            j => j.HasOne<Member>().WithMany().HasForeignKey("MemberId"),
                //            j => j.HasOne<AikidoEvent>().WithMany().HasForeignKey("EventId")
                //        );

                builder.HasOne(e => e.Organizer)
                       .WithMany()
                       .HasForeignKey(e => e.OrganizerId)
                       .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(e => e.Presenter)
                       .WithMany()
                       .HasForeignKey(e => e.PresenterId)
                       .OnDelete(DeleteBehavior.Restrict);

                builder.OwnsOne(e => e.Address);
                builder.OwnsOne(e => e.Contact);
            });

            // Organization
            modelBuilder.Entity<Organization>(builder =>
            {
                builder.HasMany(o => o.Dojos)
                       .WithOne()
                       .HasForeignKey("OrganizationId")
                       .OnDelete(DeleteBehavior.Cascade);

                builder.OwnsOne(o => o.Contact);
                builder.OwnsOne(o => o.Address);
            });
        }
    }
}