using System.Collections.Generic;
using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    public class RecordType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore] public ICollection<Record> Records { get; set; }
    }
}