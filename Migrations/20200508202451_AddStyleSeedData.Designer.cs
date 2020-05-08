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
    [Migration("20200508202451_AddStyleSeedData")]
    partial class AddStyleSeedData
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
                            Name = "Country"
                        },
                        new
                        {
                            Id = -5,
                            Name = "Latin"
                        },
                        new
                        {
                            Id = -6,
                            Name = "Hip hop"
                        },
                        new
                        {
                            Id = -7,
                            Name = "Jazz"
                        },
                        new
                        {
                            Id = -8,
                            Name = "Pop"
                        },
                        new
                        {
                            Id = -9,
                            Name = "Classical"
                        },
                        new
                        {
                            Id = -10,
                            Name = "Avant-garde"
                        },
                        new
                        {
                            Id = -11,
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

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnName("label")
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

                    b.Property<DateTime>("Year")
                        .HasColumnName("year")
                        .HasColumnType("date");

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
                        },
                        new
                        {
                            Id = -3,
                            GenreId = -2,
                            Name = "Downtempo"
                        },
                        new
                        {
                            Id = -4,
                            GenreId = -2,
                            Name = "Drum and bass"
                        },
                        new
                        {
                            Id = -5,
                            GenreId = -2,
                            Name = "Dub"
                        },
                        new
                        {
                            Id = -6,
                            GenreId = -2,
                            Name = "Electroacoustic"
                        },
                        new
                        {
                            Id = -7,
                            GenreId = -2,
                            Name = "Electronica"
                        },
                        new
                        {
                            Id = -8,
                            GenreId = -2,
                            Name = "House"
                        },
                        new
                        {
                            Id = -9,
                            GenreId = -2,
                            Name = "Industrial"
                        },
                        new
                        {
                            Id = -10,
                            GenreId = -2,
                            Name = "Jungle"
                        },
                        new
                        {
                            Id = -11,
                            GenreId = -2,
                            Name = "Techno"
                        },
                        new
                        {
                            Id = -12,
                            GenreId = -2,
                            Name = "UK garage"
                        },
                        new
                        {
                            Id = -13,
                            GenreId = -1,
                            Name = "Alternative rock"
                        },
                        new
                        {
                            Id = -14,
                            GenreId = -1,
                            Name = "Experimental rock"
                        },
                        new
                        {
                            Id = -15,
                            GenreId = -1,
                            Name = "Heavy metal"
                        },
                        new
                        {
                            Id = -16,
                            GenreId = -1,
                            Name = "Punk rock"
                        },
                        new
                        {
                            Id = -17,
                            GenreId = -1,
                            Name = "Rap rock"
                        },
                        new
                        {
                            Id = -18,
                            GenreId = -1,
                            Name = "New wave"
                        },
                        new
                        {
                            Id = -19,
                            GenreId = -1,
                            Name = "Psychedelic rock"
                        },
                        new
                        {
                            Id = -20,
                            GenreId = -1,
                            Name = "Progressive rock"
                        },
                        new
                        {
                            Id = -21,
                            GenreId = -3,
                            Name = "Contemporary R&B"
                        },
                        new
                        {
                            Id = -22,
                            GenreId = -3,
                            Name = "Disco"
                        },
                        new
                        {
                            Id = -23,
                            GenreId = -3,
                            Name = "Funk"
                        },
                        new
                        {
                            Id = -24,
                            GenreId = -3,
                            Name = "Soul"
                        },
                        new
                        {
                            Id = -25,
                            GenreId = -3,
                            Name = "Alternative R&B"
                        },
                        new
                        {
                            Id = -27,
                            GenreId = -4,
                            Name = "Classic country"
                        },
                        new
                        {
                            Id = -28,
                            GenreId = -4,
                            Name = "Country blues"
                        },
                        new
                        {
                            Id = -29,
                            GenreId = -4,
                            Name = "Country rock"
                        },
                        new
                        {
                            Id = -30,
                            GenreId = -4,
                            Name = "Country pop"
                        },
                        new
                        {
                            Id = -31,
                            GenreId = -4,
                            Name = "Instrumental country"
                        },
                        new
                        {
                            Id = -32,
                            GenreId = -4,
                            Name = "Texas country"
                        },
                        new
                        {
                            Id = -33,
                            GenreId = -5,
                            Name = "Brazilian"
                        },
                        new
                        {
                            Id = -34,
                            GenreId = -5,
                            Name = "Latin jazz"
                        },
                        new
                        {
                            Id = -35,
                            GenreId = -5,
                            Name = "Latin rock"
                        },
                        new
                        {
                            Id = -36,
                            GenreId = -5,
                            Name = "Reggaeton"
                        },
                        new
                        {
                            Id = -37,
                            GenreId = -5,
                            Name = "Regional Mexican"
                        },
                        new
                        {
                            Id = -38,
                            GenreId = -5,
                            Name = "Traditional"
                        },
                        new
                        {
                            Id = -39,
                            GenreId = -5,
                            Name = "Tropical"
                        },
                        new
                        {
                            Id = -40,
                            GenreId = -6,
                            Name = "Alternative hip hop"
                        },
                        new
                        {
                            Id = -41,
                            GenreId = -6,
                            Name = "Experimental hip hop"
                        },
                        new
                        {
                            Id = -42,
                            GenreId = -6,
                            Name = "British hip hop"
                        },
                        new
                        {
                            Id = -43,
                            GenreId = -6,
                            Name = "Cloud rap"
                        },
                        new
                        {
                            Id = -44,
                            GenreId = -6,
                            Name = "Conscious hip hop"
                        },
                        new
                        {
                            Id = -45,
                            GenreId = -6,
                            Name = "G-funk"
                        },
                        new
                        {
                            Id = -46,
                            GenreId = -6,
                            Name = "Gangsta rap"
                        },
                        new
                        {
                            Id = -47,
                            GenreId = -6,
                            Name = "Hardcore hip hop"
                        },
                        new
                        {
                            Id = -48,
                            GenreId = -6,
                            Name = "Grime"
                        },
                        new
                        {
                            Id = -49,
                            GenreId = -6,
                            Name = "Mumble rap"
                        },
                        new
                        {
                            Id = -50,
                            GenreId = -6,
                            Name = "Trap"
                        },
                        new
                        {
                            Id = -51,
                            GenreId = -6,
                            Name = "West Coast hip hop"
                        },
                        new
                        {
                            Id = -52,
                            GenreId = -7,
                            Name = "Avant-garde jazz"
                        },
                        new
                        {
                            Id = -53,
                            GenreId = -7,
                            Name = "Free jazz"
                        },
                        new
                        {
                            Id = -54,
                            GenreId = -7,
                            Name = "Swing"
                        },
                        new
                        {
                            Id = -55,
                            GenreId = -7,
                            Name = "Jazz fusion"
                        },
                        new
                        {
                            Id = -56,
                            GenreId = -7,
                            Name = "Smooth jazz"
                        },
                        new
                        {
                            Id = -57,
                            GenreId = -7,
                            Name = "Chamber jazz"
                        },
                        new
                        {
                            Id = -58,
                            GenreId = -8,
                            Name = "Baroque pop"
                        },
                        new
                        {
                            Id = -59,
                            GenreId = -8,
                            Name = "Europop"
                        },
                        new
                        {
                            Id = -60,
                            GenreId = -8,
                            Name = "Pop rock"
                        },
                        new
                        {
                            Id = -61,
                            GenreId = -8,
                            Name = "Psychedelic pop"
                        },
                        new
                        {
                            Id = -62,
                            GenreId = -8,
                            Name = "Indie pop"
                        },
                        new
                        {
                            Id = -63,
                            GenreId = -8,
                            Name = "K-pop"
                        },
                        new
                        {
                            Id = -64,
                            GenreId = -8,
                            Name = "Synthpop"
                        },
                        new
                        {
                            Id = -65,
                            GenreId = -9,
                            Name = "Ancient"
                        },
                        new
                        {
                            Id = -66,
                            GenreId = -9,
                            Name = "Early"
                        },
                        new
                        {
                            Id = -67,
                            GenreId = -9,
                            Name = "Modern"
                        },
                        new
                        {
                            Id = -68,
                            GenreId = -9,
                            Name = "Postmodern"
                        },
                        new
                        {
                            Id = -69,
                            GenreId = -9,
                            Name = "Contemporary"
                        },
                        new
                        {
                            Id = -70,
                            GenreId = -10,
                            Name = "Experimental"
                        },
                        new
                        {
                            Id = -71,
                            GenreId = -10,
                            Name = "Noise"
                        },
                        new
                        {
                            Id = -72,
                            GenreId = -10,
                            Name = "Musique concrète"
                        },
                        new
                        {
                            Id = -73,
                            GenreId = -11,
                            Name = "Blues rock"
                        },
                        new
                        {
                            Id = -74,
                            GenreId = -11,
                            Name = "Detroit blues"
                        },
                        new
                        {
                            Id = -75,
                            GenreId = -11,
                            Name = "Texas blues"
                        },
                        new
                        {
                            Id = -76,
                            GenreId = -11,
                            Name = "British blues"
                        },
                        new
                        {
                            Id = -77,
                            GenreId = -11,
                            Name = "Gospel blues"
                        },
                        new
                        {
                            Id = -78,
                            GenreId = -11,
                            Name = "Soul blues"
                        },
                        new
                        {
                            Id = -79,
                            GenreId = -11,
                            Name = "St. Louis blues"
                        },
                        new
                        {
                            Id = -80,
                            GenreId = -11,
                            Name = "Chicago blues"
                        },
                        new
                        {
                            Id = -81,
                            GenreId = -11,
                            Name = "Electric blues"
                        });
                });

            modelBuilder.Entity("record_keep_api.DBO.UserActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ActionId")
                        .HasColumnName("action_id")
                        .HasColumnType("integer");

                    b.Property<int?>("CollectionId")
                        .HasColumnName("collection_id")
                        .HasColumnType("integer");

                    b.Property<int>("OwnerId")
                        .HasColumnName("owner_id")
                        .HasColumnType("integer");

                    b.Property<int?>("RecordId")
                        .HasColumnName("record_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("time_stamp")
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now() at time zone 'utc'");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("CollectionId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RecordId");

                    b.ToTable("user_activity");
                });

            modelBuilder.Entity("record_keep_api.DBO.UserActivityAction", b =>
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

                    b.ToTable("user_activity_action");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "CollectionCreate"
                        },
                        new
                        {
                            Id = -2,
                            Name = "CollectionUpdate"
                        },
                        new
                        {
                            Id = -3,
                            Name = "CollectionDelete"
                        },
                        new
                        {
                            Id = -4,
                            Name = "RecordCreate"
                        },
                        new
                        {
                            Id = -5,
                            Name = "RecordDelete"
                        },
                        new
                        {
                            Id = -6,
                            Name = "RecordUpdate"
                        },
                        new
                        {
                            Id = -7,
                            Name = "ImageCreate"
                        },
                        new
                        {
                            Id = -8,
                            Name = "ImageUpdate"
                        },
                        new
                        {
                            Id = -9,
                            Name = "UserUpdate"
                        },
                        new
                        {
                            Id = -10,
                            Name = "CollectionDeleteWithMove"
                        },
                        new
                        {
                            Id = -11,
                            Name = "PasswordChange"
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

            modelBuilder.Entity("record_keep_api.DBO.UserActivity", b =>
                {
                    b.HasOne("record_keep_api.DBO.UserActivityAction", "Action")
                        .WithMany("Activities")
                        .HasForeignKey("ActionId")
                        .HasConstraintName("user_activity_action_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("record_keep_api.DBO.Collection", "Collection")
                        .WithMany("Activities")
                        .HasForeignKey("CollectionId")
                        .HasConstraintName("user_activity_collection_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("record_keep_api.DBO.UserData", "Owner")
                        .WithMany("UserActivities")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("user_activity_owner_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("record_keep_api.DBO.Record", "Record")
                        .WithMany("Activities")
                        .HasForeignKey("RecordId")
                        .HasConstraintName("user_activity_record_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade);
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
