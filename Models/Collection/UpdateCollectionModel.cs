using System.ComponentModel.DataAnnotations;

namespace record_keep_api.Models.Collection
{
    public class UpdateCollectionModel
    {
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        public int? ImageId { get; set; }
    }
}