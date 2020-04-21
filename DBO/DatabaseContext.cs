﻿using Microsoft.EntityFrameworkCore;
using record_keep_api.Migrations;

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
        public DbSet<CollectionRecords> CollectionRecords { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<RecordType> RecordType { get; set; }
        public DbSet<UserData> UserData { get; set; }

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

                entity.HasOne(d => d.Owner);
            });

            modelBuilder.Entity<CollectionRecords>(entity =>
            {
                entity.HasKey(e => new {e.CollectionId, e.RecordId})
                    .HasName("collection_records_pkey");

                entity.ToTable("collection_records");

                entity.Property(e => e.CollectionId).HasColumnName("collection_id");

                entity.Property(e => e.RecordId).HasColumnName("record_id");

                entity.HasOne(d => d.Collection)
                    .WithMany(p => p.CollectionRecordsCollection)
                    .HasForeignKey(d => d.CollectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_records_collection_id_fkey");

                entity.HasOne(d => d.Record)
                    .WithMany(p => p.CollectionRecordsRecord)
                    .HasForeignKey(d => d.RecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("collection_records_record_id_fkey");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image");

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.Data).HasColumnName("data").IsRequired();

                entity.Property(e => e.CreatorId).HasColumnName("creator_id").IsRequired();

                entity.HasOne(e => e.Creator).WithMany(e => e.CreatedImages).HasForeignKey(e => e.CreatorId)
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

                entity.Property(e => e.RecordTypeId).HasColumnName("record_type_id");

                entity.HasOne(d => d.RecordType)
                    .WithMany(p => p.Record)
                    .HasForeignKey(d => d.RecordTypeId)
                    .HasConstraintName("record_record_type_id_fkey");
            });

            modelBuilder.Entity<RecordType>(entity =>
            {
                entity.ToTable("record_type");

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsRequired();
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

                entity.HasOne(d => d.ProfileImage).WithMany(image => image.ProfileImages)
                    .HasForeignKey(e => e.ProfileImageId)
                    .HasConstraintName("profile_image_profile_images_id_fkey");
            });

            modelBuilder.Seed();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}