using System.Collections.Generic;

namespace record_keep_api.DBO
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Data { get; set; }

        public int CreatorId { get; set; }
        public UserData Creator { get; set; }

        public ICollection<UserData> ProfileImages { get; set; }
    }
}