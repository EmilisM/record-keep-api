using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Image = System.Drawing.Image;

namespace record_keep_api.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> GetImageCroppedAsync(string data, string x, string y, string width, string height)
        {
            var imageSource = await Base64ToBitmapAsync(data);

            var outcomeWidth = int.TryParse(width, out var widthParsed);
            var outcomeHeight = int.TryParse(height, out var heightParsed);
            var outcomeX = int.TryParse(x, out var xParsed);
            var outcomeY = int.TryParse(y, out var yParsed);

            if (!outcomeWidth || !outcomeHeight || !outcomeX || !outcomeY)
            {
                return null;
            }

            var rectangle = new Rectangle(xParsed, yParsed, widthParsed, heightParsed);
            var dest = imageSource.Clone(rectangle, imageSource.PixelFormat);

            return BitmapToBase64(dest);
        }

        private static async Task<Bitmap> Base64ToBitmapAsync(string base64String)
        {
            var bytes = Convert.FromBase64String(base64String);
            var memoryStream = new MemoryStream(bytes, 0, bytes.Length);

            await memoryStream.WriteAsync(bytes, 0, bytes.Length);

            var image = Image.FromStream(memoryStream, true);
            var bitmapImage = new Bitmap(image);

            return bitmapImage;
        }

        private static string BitmapToBase64(Image bitmapImage)
        {
            var memoryStream = new MemoryStream();
            bitmapImage.Save(memoryStream, ImageFormat.Png);
            var byteImages = memoryStream.ToArray();

            var base64String = Convert.ToBase64String(byteImages);

            return base64String;
        }
    }
}