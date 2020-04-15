using Microsoft.EntityFrameworkCore;
using record_keep_api.Migrations;

namespace record_keep_api.DBO
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Collection> Collection { get; set; }
        public virtual DbSet<CollectionRecords> CollectionRecords { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Record> Record { get; set; }
        public virtual DbSet<RecordType> RecordType { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }

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

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Collection)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("collection_owner_id_fkey");
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

                entity.Property(e => e.Url).HasColumnName("url").IsRequired();
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

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("user_data_image_id_fkey");
            });

            modelBuilder.Seed();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}