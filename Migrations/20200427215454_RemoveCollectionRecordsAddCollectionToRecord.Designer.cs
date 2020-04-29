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
    [Migration("20200427215454_RemoveCollectionRecordsAddCollectionToRecord")]
    partial class RemoveCollectionRecordsAddCollectionToRecord
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

                    b.HasIndex("OwnerId");

                    b.HasIndex("RecordTypeId");

                    b.ToTable("record");
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
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

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

                    b.HasOne("record_keep_api.DBO.UserData", "Owner")
                        .WithMany("Records")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("record_owner_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("record_keep_api.DBO.RecordType", "RecordType")
                        .WithMany("Record")
                        .HasForeignKey("RecordTypeId")
                        .HasConstraintName("record_record_type_id_fkey")
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