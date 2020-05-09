using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    public class RecordStyle
    {
        public int RecordId { get; set; }
        [JsonIgnore] public Record Record { get; set; }

        public int StyleId { get; set; }
        public Style Style { get; set; }
    }
}