using System;
using Microsoft.EntityFrameworkCore;
using record_keep_api.Migrations;
using record_keep_api.Models.UserActivity;

namespace record_keep_api.DBO
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Collection> Collection { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<RecordType> RecordType { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Style> Style { get; set; }
        public DbSet<RecordStyles> RecordStyles { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<UserActivityAction> UserActivityActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("collection");

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name).HasColumnName("name").IsRequired();

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.HasOne(e => e.Owner);

                entity.HasOne(e => e.Image)
                    .WithMany(e => e.Collections)
                    .HasForeignKey(e => e.ImageId)
                    .HasConstraintName("collection_images_fkey");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image");

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.Data).HasColumnName("data").IsRequired();

                entity.Property(e => e.CreatorId).HasColumnName("creator_id").IsRequired();

                entity.HasOne(e => e.Creator)
                    .WithMany(e => e.CreatedImages)
                    .HasForeignKey(e => e.CreatorId)
                    .HasConstraintName("image_created_image_id_fkey");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.ToTable("record");

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.Artist).HasColumnName("artist").IsRequired();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.Name).HasColumnName("name").IsRequired();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.CollectionId).HasColumnName("collection_id");

                entity.HasOne(e => e.Collection)
                    .WithMany(e => e.Records)
                    .HasForeignKey(d => d.CollectionId)
                    .HasConstraintName("record_collection_id_fkey");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.HasOne(e => e.Owner)
                    .WithMany(e => e.Records)
                    .HasForeignKey(e => e.OwnerId)
                    .HasConstraintName("record_owner_id_fkey");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.HasOne(e => e.Image)
                    .WithMany(e => e.Records)
                    .HasForeignKey(e => e.ImageId)
                    .HasConstraintName("record_image_id_fkey");

                entity.Property(e => e.RecordTypeId).HasColumnName("record_type_id");

                entity.HasOne(e => e.RecordType)
                    .WithMany(e => e.Records)
                    .HasForeignKey(e => e.RecordTypeId)
                    .HasConstraintName("record_record_type_id_fkey");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.Label).HasColumnName("label").IsRequired();
            });

            modelBuilder.Entity<UserData>(entity =>
            {
                entity.ToTable("user_data");

                entity.HasIndex(e => e.Email)
                    .HasName("user_data_email_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.PasswordHash).HasColumnName("password_hash").IsRequired();

                entity.Property(e => e.PasswordSalt).HasColumnName("password_salt").IsRequired();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .IsRequired();

                entity.Property(e => e.DisplayName)
                    .HasColumnName("display_name");

                entity.Property(e => e.ProfileImageId).HasColumnName("profile_image_id");

                entity.HasOne(d => d.ProfileImage)
                    .WithMany(image => image.Profiles)
                    .HasForeignKey(e => e.ProfileImageId)
                    .HasConstraintName("profile_image_profiles_id_fkey");
            });

            modelBuilder.Entity<RecordType>(entity =>
            {
                entity.ToTable("record_type");

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.HasIndex(e => e.Name)
                    .HasName("record_type_name_key")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.HasIndex(e => e.Name)
                    .HasName("genre_name_key")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.ToTable("style");

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.HasIndex(e => e.Name)
                    .HasName("style_name_key")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.HasOne(e => e.Genre)
                    .WithMany(e => e.Styles)
                    .HasForeignKey(e => e.GenreId)
                    .HasConstraintName("style_genre_id_fkey");
            });

            modelBuilder.Entity<RecordStyles>(entity =>
            {
                entity.ToTable("record_styles");

                entity.Property(e => e.RecordId).HasColumnName("record_id");

                entity.Property(e => e.StyleId).HasColumnName("style_id");

                entity.HasKey(e => new {e.RecordId, e.StyleId});

                entity.HasOne(e => e.Record)
                    .WithMany(e => e.RecordStyles)
                    .HasForeignKey(e => e.RecordId).HasConstraintName("record_styles_record_id_fkey");

                entity.HasOne(e => e.Style)
                    .WithMany(e => e.RecordStyles)
                    .HasForeignKey(e => e.StyleId)
                    .HasConstraintName("record_styles_style_id_fkey");
            });


            modelBuilder.Entity<UserActivityAction>(entity =>
            {
                entity.ToTable("user_activity_action");

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasConversion(
                        v => v.ToString(),
                        v => (UserActivityActionName) Enum.Parse(typeof(UserActivityActionName), v));
            });

            modelBuilder.Entity<UserActivity>(entity =>
            {
                entity.ToTable("user_activity");

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("time_stamp")
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.HasOne(e => e.Owner)
                    .WithMany(e => e.UserActivities)
                    .HasForeignKey(e => e.OwnerId)
                    .HasConstraintName("user_activity_owner_id_fkey");

                entity.Property(e => e.ActionId).HasColumnName("action_id");

                entity.HasOne(e => e.Action)
                    .WithMany(e => e.Activities)
                    .HasForeignKey(e => e.ActionId)
                    .HasConstraintName("user_activity_action_id_fkey");

                entity.Property(e => e.CollectionId).HasColumnName("collection_id");

                entity.HasOne(e => e.Collection)
                    .WithMany(e => e.Activities)
                    .HasForeignKey(e => e.CollectionId)
                    .HasConstraintName("user_activity_collection_id_fkey");

                entity.Property(e => e.RecordId).HasColumnName("record_id");

                entity.HasOne(e => e.Record)
                    .WithMany(e => e.RecordActivities)
                    .HasForeignKey(e => e.RecordId)
                    .HasConstraintName("user_activity_record_id_fkey");
            });

            modelBuilder.Seed();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}