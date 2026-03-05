using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DojoDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Dojo> Dojos { get; set; }
        public DbSet<AikidoEvent> AikidoEvents { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DojoDbContext(DbContextOptions<DojoDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Member
            modelBuilder.Entity<Member>(builder =>
            {
                // Global query filter for logical deletion
                builder.HasQueryFilter(m => m.IsActive);

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
                    ti.OwnsMany(t => t.Notes, nb =>
                    {
                        nb.WithOwner().HasForeignKey("TraineeInfoId");
                        nb.HasKey(n => n.Id);
                        nb.Property(n => n.Content).IsRequired();
                        nb.Property(n => n.CreatedAt).IsRequired();
                        nb.Property(n => n.CreatedByMemberId).IsRequired();
                    });

                    // DojoId is just a scalar property
                    ti.Property(t => t.DojoId).IsRequired();
                });

                // Name as an owned type
                builder.OwnsOne(m => m.Name);
            });
            // Dojo
            modelBuilder.Entity<Dojo>(builder =>
            {
                builder.Property(d => d.Name).IsRequired();
                builder.OwnsOne(d => d.Contact);
                builder.OwnsOne(d => d.Address);

                builder.HasOne<Member>()
                    .WithMany()
                    .HasForeignKey(d => d.DojoChoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            // AikidoEvent
            modelBuilder.Entity<AikidoEvent>(builder =>
            {
                // Many-to-many join table for attendees
                builder.HasMany<Member>()
                       .WithMany()
                       .UsingEntity<Dictionary<string, object>>(
                           "EventAttendees",
                           j => j.HasOne<Member>().WithMany().HasForeignKey("MemberId"),
                           j => j.HasOne<AikidoEvent>().WithMany().HasForeignKey("EventId")
                       );

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