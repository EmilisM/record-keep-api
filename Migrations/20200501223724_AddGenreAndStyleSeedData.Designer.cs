﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using record_keep_api.DBO;

namespace record_keep_api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200501223724_AddGenreAndStyleSeedData")]
    partial class AddGenreAndStyleSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("record_keep_api.DBO.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("creation_date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<int?>("ImageId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnName("owner_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("OwnerId");

                    b.ToTable("collection");
                });

            modelBuilder.Entity("record_keep_api.DBO.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("genre_name_key");

                    b.ToTable("genre");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "Rock"
                        },
                        new
                        {
                            Id = -2,
                            Name = "Electronic"
                        },
                        new
                        {
                            Id = -3,
                            Name = "Soul/R&B"
                        },
                        new
                        {
                            Id = -4,
                            Name = "Funk"
                        },
                        new
                        {
                            Id = -5,
                            Name = "Country"
                        },
                        new
                        {
                            Id = -6,
                            Name = "Latin"
                        },
                        new
                        {
                            Id = -7,
                            Name = "Reggae"
                        },
                        new
                        {
                            Id = -8,
                            Name = "Hip hop music"
                        },
                        new
                        {
                            Id = -9,
                            Name = "Jazz"
                        },
                        new
                        {
                            Id = -10,
                            Name = "Pop"
                        },
                        new
                        {
                            Id = -11,
                            Name = "Classical"
                        },
                        new
                        {
                            Id = -12,
                            Name = "Avant-garde"
                        },
                        new
                        {
                            Id = -13,
                            Name = "Blues"
                        });
                });

            modelBuilder.Entity("record_keep_api.DBO.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CreatorId")
                        .HasColumnName("creator_id")
                        .HasColumnType("integer");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnName("data")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("image");
                });

            modelBuilder.Entity("record_keep_api.DBO.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnName("artist")
                        .HasColumnType("text");

                    b.Property<int>("CollectionId")
                        .HasColumnName("collection_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("creation_date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<int?>("ImageId")
                        .HasColumnName("image_id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnName("owner_id")
                        .HasColumnType("integer");

                    b.Property<int>("RecordTypeId")
                        .HasColumnName("record_type_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("ImageId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RecordTypeId");

                    b.ToTable("record");
                });

            modelBuilder.Entity("record_keep_api.DBO.RecordStyles", b =>
                {
                    b.Property<int>("RecordId")
                        .HasColumnName("record_id")
                        .HasColumnType("integer");

                    b.Property<int>("StyleId")
                        .HasColumnName("style_id")
                        .HasColumnType("integer");

                    b.HasKey("RecordId", "StyleId");

                    b.HasIndex("StyleId");

                    b.ToTable("record_styles");
                });

            modelBuilder.Entity("record_keep_api.DBO.RecordType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("record_type_name_key");

                    b.ToTable("record_type");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "LP"
                        },
                        new
                        {
                            Id = -2,
                            Name = "CD"
                        },
                        new
                        {
                            Id = -3,
                            Name = "Vinyl"
                        },
                        new
                        {
                            Id = -4,
                            Name = "Tape"
                        });
                });

            modelBuilder.Entity("record_keep_api.DBO.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GenreId")
                        .HasColumnName("genre_id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("style_name_key");

                    b.ToTable("style");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            GenreId = -2,
                            Name = "IDM"
                        },
                        new
                        {
                            Id = -2,
                            GenreId = -2,
                            Name = "Ambient"
                        });
                });

            modelBuilder.Entity("record_keep_api.DBO.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("creation_date")
                        .HasColumnType("date");

                    b.Property<string>("DisplayName")
                        .HasColumnName("display_name")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnName("password_hash")
                        .HasColumnType("text");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnName("password_salt")
                        .HasColumnType("text");

                    b.Property<int?>("ProfileImageId")
                        .HasColumnName("profile_image_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("user_data_email_key");

                    b.HasIndex("ProfileImageId");

                    b.ToTable("user_data");
                });

            modelBuilder.Entity("record_keep_api.DBO.Collection", b =>
                {
                    b.HasOne("record_keep_api.DBO.Image", "Image")
                        .WithMany("Collections")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("collection_images_fkey");

                    b.HasOne("record_keep_api.DBO.UserData", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("record_keep_api.DBO.Image", b =>
                {
                    b.HasOne("record_keep_api.DBO.UserData", "Creator")
                        .WithMany("CreatedImages")
                        .HasForeignKey("CreatorId")
                        .HasConstraintName("image_created_image_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("record_keep_api.DBO.Record", b =>
                {
                    b.HasOne("record_keep_api.DBO.Collection", "Collection")
                        .WithMany("Records")
                        .HasForeignKey("CollectionId")
                        .HasConstraintName("record_collection_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("record_keep_api.DBO.Image", "Image")
                        .WithMany("Records")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("record_image_id_fkey");

                    b.HasOne("record_keep_api.DBO.UserData", "Owner")
                        .WithMany("Records")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("record_owner_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("record_keep_api.DBO.RecordType", "RecordType")
                        .WithMany("Records")
                        .HasForeignKey("RecordTypeId")
                        .HasConstraintName("record_record_type_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("record_keep_api.DBO.RecordStyles", b =>
                {
                    b.HasOne("record_keep_api.DBO.Record", "Record")
                        .WithMany("RecordStyles")
                        .HasForeignKey("RecordId")
                        .HasConstraintName("record_styles_record_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("record_keep_api.DBO.Style", "Style")
                        .WithMany("RecordStyles")
                        .HasForeignKey("StyleId")
                        .HasConstraintName("record_styles_style_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("record_keep_api.DBO.Style", b =>
                {
                    b.HasOne("record_keep_api.DBO.Genre", "Genre")
                        .WithMany("Styles")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("style_genre_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("record_keep_api.DBO.UserData", b =>
                {
                    b.HasOne("record_keep_api.DBO.Image", "ProfileImage")
                        .WithMany("Profiles")
                        .HasForeignKey("ProfileImageId")
                        .HasConstraintName("profile_image_profiles_id_fkey");
                });
#pragma warning restore 612, 618
        }
    }
}
