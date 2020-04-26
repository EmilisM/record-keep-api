using System;

namespace record_keep_api.Models.Collection
{
    public class CollectionResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public int OwnerId { get; set; }

        public int? ImageId { get; set; }
        public DBO.Image Image { get; set; }

        public int RecordCount { get; set; }
    }
}