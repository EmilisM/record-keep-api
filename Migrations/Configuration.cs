using Microsoft.EntityFrameworkCore;
using record_keep_api.DBO;

namespace record_keep_api.Migrations
{
    public static class Configuration
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecordType>().HasData(
                new RecordType
                {
                    Id = -1,
                    Name = "LP",
                },
                new RecordType
                {
                    Id = -2,
                    Name = "CD"
                },
                new RecordType
                {
                    Id = -3,
                    Name = "Vinyl"
                },
                new RecordType
                {
                    Id = -4,
                    Name = "Tape"
                }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = -1,
                    Name = "Rock"
                },
                new Genre
                {
                    Id = -2,
                    Name = "Electronic"
                },
                new Genre
                {
                    Id = -3,
                    Name = "Soul/R&B"
                },
                new Genre
                {
                    Id = -4,
                    Name = "Funk"
                },
                new Genre
                {
                    Id = -5,
                    Name = "Country"
                },
                new Genre
                {
                    Id = -6,
                    Name = "Latin"
                },
                new Genre
                {
                    Id = -7,
                    Name = "Reggae"
                },
                new Genre
                {
                    Id = -8,
                    Name = "Hip hop music"
                },
                new Genre
                {
                    Id = -9,
                    Name = "Jazz"
                },
                new Genre
                {
                    Id = -10,
                    Name = "Pop"
                },
                new Genre
                {
                    Id = -11,
                    Name = "Classical"
                },
                new Genre
                {
                    Id = -12,
                    Name = "Avant-garde"
                },
                new Genre
                {
                    Id = -13,
                    Name = "Blues"
                }
            );

            modelBuilder.Entity<Style>().HasData(
                new Style
                {
                    Id = -1,
                    Name = "IDM",
                    GenreId = -2
                },
                new Style
                {
                    Id = -2,
                    Name = "Ambient",
                    GenreId = -2
                }
            );
        }
    }
}