using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace record_keep_api.DBO
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class Record
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Year { get; set; }
        public string Label { get; set; }

        public int CollectionId { get; set; }
        [JsonIgnore] public Collection Collection { get; set; }

        [JsonIgnore] public int OwnerId { get; set; }
        [JsonIgnore] public UserData Owner { get; set; }

        [JsonIgnore] public int? ImageId { get; set; }
        public Image Image { get; set; }

        [JsonIgnore] public int RecordTypeId { get; set; }
        public RecordType RecordType { get; set; }

        [JsonIgnore] public ICollection<RecordStyles> RecordStyles { get; set; }
    }
}