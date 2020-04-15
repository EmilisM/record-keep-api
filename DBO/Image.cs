using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    public partial class Image
    {
        [JsonIgnore] public int Id { get; set; }
        public string Url { get; set; }
    }
}