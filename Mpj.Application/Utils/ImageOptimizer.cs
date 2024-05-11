using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace Mpj.Application.Utils
{
    public class ImageOptimizer
    {
        public void ImageResizer(string inputImagePath, string outputImagePath, string format, int? width, int? height)
        {
            var customWidth = width ?? 100;

            var customHeight = height ?? 100;

            using (var image = SixLabors.ImageSharp.Image.Load(inputImagePath))
            {
                image.Mutate(x => x.Resize(customWidth, customHeight));
                if (format.ToLower() == ".jpg"
                    || format.ToLower() == ".gif"
                    || format.ToLower() == ".jpeg")
                {
                    image.Save(outputImagePath, new JpegEncoder
                    {
                        Quality = 100
                    });
                }
                else if (format.ToLower() == ".png")
                    image.Save(outputImagePath, new PngEncoder());
            }
        }
    }
}
