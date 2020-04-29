using System.ComponentModel.DataAnnotations;

namespace record_keep_api.Models.Record
{
    public class CreateRecordModel
    {
        [Required] public string Artist { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Description { get; set; }

        [Required] public int CollectionId { get; set; }
    }
}