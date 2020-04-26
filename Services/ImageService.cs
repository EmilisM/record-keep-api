using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Image = System.Drawing.Image;

namespace record_keep_api.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> GetImageCroppedAsync(string data, double percentageX, double percentageY,
            double percentageWidth,
            double percentageHeight)
        {
            var imageSource = await Base64ToBitmapAsync(data);

            var actualHeight = imageSource.Height;
            var actualWidth = imageSource.Width;

            var x = (int) Math.Round((percentageX / 100d) * actualWidth);
            var y = (int) Math.Round((percentageY / 100d) * actualHeight);

            var height = (int) Math.Round((percentageHeight / 100d) * actualHeight);
            var width = (int) Math.Round((percentageWidth / 100d) * actualWidth);

            var rectangle = new Rectangle(x, y, width, height);
            var dest = new Bitmap(imageSource.Clone(rectangle, imageSource.PixelFormat), 128, 128);

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

            var encoderParam = new EncoderParameter(Encoder.Quality, 100L);
            var encoderParams = new EncoderParameters
            {
                Param = new[] {encoderParam}
            };

            var encoders = ImageCodecInfo
                .GetImageEncoders()
                .First(t => t.MimeType == "image/jpeg");

            bitmapImage.Save(memoryStream, encoders, encoderParams);
            var byteImages = memoryStream.ToArray();

            var base64String = Convert.ToBase64String(byteImages);

            return base64String;
        }
    }
}