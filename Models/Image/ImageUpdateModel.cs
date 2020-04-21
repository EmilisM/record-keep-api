using System.ComponentModel.DataAnnotations;

namespace record_keep_api.Models.Image
{
    public class ImageUpdateModel
    {
        [Required] public string Data { get; set; }

        [Required] public string X { get; set; }
        [Required] public string Y { get; set; }

        [Required] public string Width { get; set; }
        [Required] public string Height { get; set; }
    }
}