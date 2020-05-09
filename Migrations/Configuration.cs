using Microsoft.EntityFrameworkCore;
using record_keep_api.DBO;
using record_keep_api.Models.UserActivity;

namespace record_keep_api.Migrations
{
    public static class Configuration
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecordFormat>().HasData(
                new RecordFormat
                {
                    Id = -1,
                    Name = "LP",
                },
                new RecordFormat
                {
                    Id = -2,
                    Name = "CD"
                },
                new RecordFormat
                {
                    Id = -3,
                    Name = "Vinyl"
                },
                new RecordFormat
                {
                    Id = -4,
                    Name = "Tape"
                },
                new RecordFormat
                {
                    Id = -5,
                    Name = "7\""
                },
                new RecordFormat
                {
                    Id = -6,
                    Name = "12\""
                },
                new RecordFormat
                {
                    Id = -7,
                    Name = "File"
                }
            );

            modelBuilder.Entity<RecordType>().HasData(
                new RecordType
                {
                    Id = -1,
                    Name = "Album",
                },
                new RecordType
                {
                    Id = -2,
                    Name = "Single"
                },
                new RecordType
                {
                    Id = -3,
                    Name = "Compilation"
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
                    Name = "Country"
                },
                new Genre
                {
                    Id = -5,
                    Name = "Latin"
                },
                new Genre
                {
                    Id = -6,
                    Name = "Hip hop"
                },
                new Genre
                {
                    Id = -7,
                    Name = "Jazz"
                },
                new Genre
                {
                    Id = -8,
                    Name = "Pop"
                },
                new Genre
                {
                    Id = -9,
                    Name = "Classical"
                },
                new Genre
                {
                    Id = -10,
                    Name = "Avant-garde"
                },
                new Genre
                {
                    Id = -11,
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
                },
                new Style
                {
                    Id = -3,
                    Name = "Downtempo",
                    GenreId = -2
                },
                new Style
                {
                    Id = -4,
                    Name = "Drum and bass",
                    GenreId = -2
                },
                new Style
                {
                    Id = -5,
                    Name = "Dub",
                    GenreId = -2
                },
                new Style
                {
                    Id = -6,
                    Name = "Electroacoustic",
                    GenreId = -2
                },
                new Style
                {
                    Id = -7,
                    Name = "Electronica",
                    GenreId = -2
                },
                new Style
                {
                    Id = -8,
                    Name = "House",
                    GenreId = -2
                },
                new Style
                {
                    Id = -9,
                    Name = "Industrial",
                    GenreId = -2
                },
                new Style
                {
                    Id = -10,
                    Name = "Jungle",
                    GenreId = -2
                },
                new Style
                {
                    Id = -11,
                    Name = "Techno",
                    GenreId = -2
                },
                new Style
                {
                    Id = -12,
                    Name = "UK garage",
                    GenreId = -2
                },
                new Style
                {
                    Id = -13,
                    Name = "Alternative rock",
                    GenreId = -1
                },
                new Style
                {
                    Id = -14,
                    Name = "Experimental rock",
                    GenreId = -1
                },
                new Style
                {
                    Id = -15,
                    Name = "Heavy metal",
                    GenreId = -1
                },
                new Style
                {
                    Id = -16,
                    Name = "Punk rock",
                    GenreId = -1
                },
                new Style
                {
                    Id = -17,
                    Name = "Rap rock",
                    GenreId = -1
                },
                new Style
                {
                    Id = -18,
                    Name = "New wave",
                    GenreId = -1
                },
                new Style
                {
                    Id = -19,
                    Name = "Psychedelic rock",
                    GenreId = -1
                },
                new Style
                {
                    Id = -20,
                    Name = "Progressive rock",
                    GenreId = -1
                },
                new Style
                {
                    Id = -21,
                    Name = "Contemporary R&B",
                    GenreId = -3
                },
                new Style
                {
                    Id = -22,
                    Name = "Disco",
                    GenreId = -3
                },
                new Style
                {
                    Id = -23,
                    Name = "Funk",
                    GenreId = -3
                },
                new Style
                {
                    Id = -24,
                    Name = "Soul",
                    GenreId = -3
                },
                new Style
                {
                    Id = -25,
                    Name = "Alternative R&B",
                    GenreId = -3
                },
                new Style
                {
                    Id = -27,
                    Name = "Classic country",
                    GenreId = -4
                },
                new Style
                {
                    Id = -28,
                    Name = "Country blues",
                    GenreId = -4
                },
                new Style
                {
                    Id = -29,
                    Name = "Country rock",
                    GenreId = -4
                },
                new Style
                {
                    Id = -30,
                    Name = "Country pop",
                    GenreId = -4
                },
                new Style
                {
                    Id = -31,
                    Name = "Instrumental country",
                    GenreId = -4
                },
                new Style
                {
                    Id = -32,
                    Name = "Texas country",
                    GenreId = -4
                },
                new Style
                {
                    Id = -33,
                    Name = "Brazilian",
                    GenreId = -5
                },
                new Style
                {
                    Id = -34,
                    Name = "Latin jazz",
                    GenreId = -5
                },
                new Style
                {
                    Id = -35,
                    Name = "Latin rock",
                    GenreId = -5
                },
                new Style
                {
                    Id = -36,
                    Name = "Reggaeton",
                    GenreId = -5
                },
                new Style
                {
                    Id = -37,
                    Name = "Regional Mexican",
                    GenreId = -5
                },
                new Style
                {
                    Id = -38,
                    Name = "Traditional",
                    GenreId = -5
                },
                new Style
                {
                    Id = -39,
                    Name = "Tropical",
                    GenreId = -5
                },
                new Style
                {
                    Id = -40,
                    Name = "Alternative hip hop",
                    GenreId = -6
                },
                new Style
                {
                    Id = -41,
                    Name = "Experimental hip hop",
                    GenreId = -6
                },
                new Style
                {
                    Id = -42,
                    Name = "British hip hop",
                    GenreId = -6
                },
                new Style
                {
                    Id = -43,
                    Name = "Cloud rap",
                    GenreId = -6
                },
                new Style
                {
                    Id = -44,
                    Name = "Conscious hip hop",
                    GenreId = -6
                },
                new Style
                {
                    Id = -45,
                    Name = "G-funk",
                    GenreId = -6
                },
                new Style
                {
                    Id = -46,
                    Name = "Gangsta rap",
                    GenreId = -6
                },
                new Style
                {
                    Id = -47,
                    Name = "Hardcore hip hop",
                    GenreId = -6
                },
                new Style
                {
                    Id = -48,
                    Name = "Grime",
                    GenreId = -6
                },
                new Style
                {
                    Id = -49,
                    Name = "Mumble rap",
                    GenreId = -6
                },
                new Style
                {
                    Id = -50,
                    Name = "Trap",
                    GenreId = -6
                },
                new Style
                {
                    Id = -51,
                    Name = "West Coast hip hop",
                    GenreId = -6
                },
                new Style
                {
                    Id = -52,
                    Name = "Avant-garde jazz",
                    GenreId = -7
                },
                new Style
                {
                    Id = -53,
                    Name = "Free jazz",
                    GenreId = -7
                },
                new Style
                {
                    Id = -54,
                    Name = "Swing",
                    GenreId = -7
                },
                new Style
                {
                    Id = -55,
                    Name = "Jazz fusion",
                    GenreId = -7
                },
                new Style
                {
                    Id = -56,
                    Name = "Smooth jazz",
                    GenreId = -7
                },
                new Style
                {
                    Id = -57,
                    Name = "Chamber jazz",
                    GenreId = -7
                },
                new Style
                {
                    Id = -58,
                    Name = "Baroque pop",
                    GenreId = -8
                },
                new Style
                {
                    Id = -59,
                    Name = "Europop",
                    GenreId = -8
                },
                new Style
                {
                    Id = -60,
                    Name = "Pop rock",
                    GenreId = -8
                },
                new Style
                {
                    Id = -61,
                    Name = "Psychedelic pop",
                    GenreId = -8
                },
                new Style
                {
                    Id = -62,
                    Name = "Indie pop",
                    GenreId = -8
                },
                new Style
                {
                    Id = -63,
                    Name = "K-pop",
                    GenreId = -8
                },
                new Style
                {
                    Id = -64,
                    Name = "Synthpop",
                    GenreId = -8
                },
                new Style
                {
                    Id = -65,
                    Name = "Ancient",
                    GenreId = -9
                },
                new Style
                {
                    Id = -66,
                    Name = "Early",
                    GenreId = -9
                },
                new Style
                {
                    Id = -67,
                    Name = "Modern",
                    GenreId = -9
                },
                new Style
                {
                    Id = -68,
                    Name = "Postmodern",
                    GenreId = -9
                },
                new Style
                {
                    Id = -69,
                    Name = "Contemporary",
                    GenreId = -9
                },
                new Style
                {
                    Id = -70,
                    Name = "Experimental",
                    GenreId = -10
                },
                new Style
                {
                    Id = -71,
                    Name = "Noise",
                    GenreId = -10
                },
                new Style
                {
                    Id = -72,
                    Name = "Musique concrète",
                    GenreId = -10
                },
                new Style
                {
                    Id = -73,
                    Name = "Blues rock",
                    GenreId = -11
                },
                new Style
                {
                    Id = -74,
                    Name = "Detroit blues",
                    GenreId = -11
                },
                new Style
                {
                    Id = -75,
                    Name = "Texas blues",
                    GenreId = -11
                },
                new Style
                {
                    Id = -76,
                    Name = "British blues",
                    GenreId = -11
                },
                new Style
                {
                    Id = -77,
                    Name = "Gospel blues",
                    GenreId = -11
                },
                new Style
                {
                    Id = -78,
                    Name = "Soul blues",
                    GenreId = -11
                },
                new Style
                {
                    Id = -79,
                    Name = "St. Louis blues",
                    GenreId = -11
                },
                new Style
                {
                    Id = -80,
                    Name = "Chicago blues",
                    GenreId = -11
                },
                new Style
                {
                    Id = -81,
                    Name = "Electric blues",
                    GenreId = -11
                }
            );

            modelBuilder.Entity<UserActivityAction>().HasData(
                new UserActivityAction
                {
                    Id = -1,
                    Name = UserActivityActionName.CollectionCreate
                },
                new UserActivityAction
                {
                    Id = -2,
                    Name = UserActivityActionName.CollectionUpdate
                },
                new UserActivityAction
                {
                    Id = -3,
                    Name = UserActivityActionName.CollectionDelete
                },
                new UserActivityAction
                {
                    Id = -4,
                    Name = UserActivityActionName.RecordCreate
                },
                new UserActivityAction
                {
                    Id = -5,
                    Name = UserActivityActionName.RecordDelete
                },
                new UserActivityAction
                {
                    Id = -6,
                    Name = UserActivityActionName.RecordUpdate
                },
                new UserActivityAction
                {
                    Id = -7,
                    Name = UserActivityActionName.ImageCreate
                },
                new UserActivityAction
                {
                    Id = -8,
                    Name = UserActivityActionName.ImageUpdate
                },
                new UserActivityAction
                {
                    Id = -9,
                    Name = UserActivityActionName.UserUpdate
                },
                new UserActivityAction
                {
                    Id = -10,
                    Name = UserActivityActionName.CollectionDeleteWithMove
                },
                new UserActivityAction
                {
                    Id = -11,
                    Name = UserActivityActionName.PasswordChange
                }
            );
        }
    }
}