using System.Threading.Tasks;
using record_keep_api.Models.Image;

namespace record_keep_api.Services
{
    public interface IImageService
    {
        public Task<string> GetImageCroppedAsync(ImageModel image, ImageOptionsModel options);
    }
}