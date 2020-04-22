using System.ComponentModel.DataAnnotations;

namespace record_keep_api.Models.Image
{
    public class ImageModel
    {
        [Required] public string Data { get; set; }

        [Required] public double X { get; set; }
        [Required] public double Y { get; set; }

        [Required] public double Width { get; set; }
        [Required] public double Height { get; set; }
    }
}