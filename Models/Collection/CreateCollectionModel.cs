using System.ComponentModel.DataAnnotations;

namespace record_keep_api.Models.Collection
{
    public class CreateCollectionModel
    {
        [Required] public string Name { get; set; }
    }
}