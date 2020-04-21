using System.Threading.Tasks;

namespace record_keep_api.Services
{
    public interface IImageService
    {
        public Task<string> GetImageCroppedAsync(string data, string x, string y, string width, string height);
    }
}