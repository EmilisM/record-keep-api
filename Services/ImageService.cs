using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using record_keep_api.Models.Image;
using Image = System.Drawing.Image;

namespace record_keep_api.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> GetImageCropped(ImageOptionsModel model)
        {
            var imageSource = await Base64ToBitmapAsync(model.Image);

            var outcomeWidth = int.TryParse(model.Width, out var width);
            var outcomeHeight = int.TryParse(model.Height, out var height);
            var outcomeX = int.TryParse(model.X, out var x);
            var outcomeY = int.TryParse(model.Y, out var y);

            if (!outcomeWidth || !outcomeHeight || !outcomeX || !outcomeY)
            {
                return null;
            }

            var rectangle = new Rectangle(x, y, width, height);
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