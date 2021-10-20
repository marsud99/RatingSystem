using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RatingSystem.Models;

#nullable disable

namespace RatingSystem.Data
{
    public partial class RatingDbContext : DbContext
    {
        public RatingDbContext(DbContextOptions<RatingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConferenceXAttendee> ConferenceXAttendees { get; set; }
        public virtual DbSet<ConferenceRating> ConferenceRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ConferenceXAttendee>(entity =>
            {
                entity.HasKey(e => e.Hash);
                entity.ToTable("ConferenceXAttendee");
                entity.Property(e => e.AttendeeEmail);


                entity.Property(e => e.ConferenceId);


                entity.Property(e => e.Rating);
            });
            modelBuilder.Entity<ConferenceRating>(entity =>
            {
                entity.HasKey(e => e.ConferenceId);
                entity.ToTable("ConferenceRating");
                entity.Property(e => e.AverageRating);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
