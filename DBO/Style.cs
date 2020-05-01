using System.Collections.Generic;
using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    public class Style
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore] public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [JsonIgnore] public ICollection<RecordStyles> RecordStyles { get; set; }
    }
}