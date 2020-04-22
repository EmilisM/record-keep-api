using System.Threading.Tasks;

namespace record_keep_api.Services
{
    public interface IImageService
    {
        public Task<string> GetImageCroppedAsync(string data, double x, double y, double width, double height);
    }
}