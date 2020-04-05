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
        }
    }
}