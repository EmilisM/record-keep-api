using System.Collections.Generic;

namespace record_keep_api.DBO
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Style> Styles { get; set; }
    }
}