using System.Collections.Generic;
using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore] public ICollection<Style> Styles { get; set; }
    }
}