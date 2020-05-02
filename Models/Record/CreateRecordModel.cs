using System.ComponentModel.DataAnnotations;

namespace record_keep_api.Models.Record
{
    public class CreateRecordModel
    {
        [Required] public string Artist { get; set; }

        [Required] public string Name { get; set; }

        public string Description { get; set; }

        [Required] public int CollectionId { get; set; }

        public int? ImageId { get; set; }

        [Required] public int RecordTypeId { get; set; }

        public int[] StyleIds { get; set; }
    }
}