using System.ComponentModel.DataAnnotations;

namespace record_keep_api.Models.Image
{
    public class ImageModel
    {
        [Required] public string Data { get; set; }
    }
}