using System.ComponentModel.DataAnnotations;

namespace record_keep_api.Models.Image
{
    public class ImageOptionsModel
    {
        [Required] public string Image { get; set; }

        [Required] public string X { get; set; }
        [Required] public string Y { get; set; }

        [Required] public string Width { get; set; }
        [Required] public string Height { get; set; }
    }
}