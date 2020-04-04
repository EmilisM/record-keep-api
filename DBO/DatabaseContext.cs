using Microsoft.EntityFrameworkCore;

namespace record_keep_api.DBO
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Collection> Collection { get; set; }
        public virtual DbSet<CollectionRecords> CollectionRecords { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Record> Record { get; set; }
        public virtual DbSet<RecordType> RecordType { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=record_keep;Username=main;Password=4Qq3!JC3id1Y");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("collection");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Collection)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("collection_owner_id_fkey");
            });

            modelBuilder.Entity<CollectionRecords>(entity =>
            {
                entity.HasKey(e => new { e.CollectionId, e.RecordId })
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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Url).HasColumnName("url");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.ToTable("record");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Artist).HasColumnName("artist");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("date");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.RecordTypeId).HasColumnName("record_type_id");

                entity.HasOne(d => d.RecordType)
                    .WithMany(p => p.Record)
                    .HasForeignKey(d => d.RecordTypeId)
                    .HasConstraintName("record_record_type_id_fkey");
            });

            modelBuilder.Entity<RecordType>(entity =>
            {
                entity.ToTable("record_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserData>(entity =>
            {
                entity.ToTable("user_data");

                entity.HasIndex(e => e.UserName)
                    .HasName("user_data_user_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("date");

                entity.Property(e => e.PasswordHash).HasColumnName("password_hash");

                entity.Property(e => e.PasswordSalt).HasColumnName("password_salt");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
