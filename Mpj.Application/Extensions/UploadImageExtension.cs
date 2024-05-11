
using Microsoft.AspNetCore.Http;
using Mpj.Application.Utils;

namespace Mpj.Application.Extensions
{
    public static class UploadImageExtension
    {
        public static void AddImageToServer(this IFormFile image, string fileName, string orginalPath, int? widthorginsmall=null, int? heightorginsamll=null,int? widthorginlarge=null, int? heightorginlarge = null, int? width=null, int? height = null, string? thumbPath = null, string? deletefileName = null)
        {
            if (image != null && image.IsImage())
            {
                if (!Directory.Exists(orginalPath))
                    Directory.CreateDirectory(orginalPath);

                if (!string.IsNullOrEmpty(deletefileName))
                {
                    if (File.Exists(orginalPath + deletefileName))
                        File.Delete(orginalPath + deletefileName);

                    if (!string.IsNullOrEmpty(thumbPath))
                    {
                        if (File.Exists(thumbPath + deletefileName))
                            File.Delete(thumbPath + deletefileName);
                    }
                }

                string OriginPathSmall = orginalPath+"Small/" + fileName;
                string OriginPathLarge = orginalPath+"Large/" + fileName;

                using (var stream = new FileStream(orginalPath + fileName, FileMode.Create))
                {
                    if (!Directory.Exists(orginalPath + fileName)) image.CopyTo(stream);
                }
                ImageOptimizer resizerorigin = new ImageOptimizer();
                if (widthorginsmall != null && heightorginsamll != null)
                    resizerorigin.ImageResizer(orginalPath + fileName, orginalPath + fileName, Path.GetExtension(image.FileName), widthorginsmall, heightorginsamll);


                //using (var stream = new FileStream(OriginPathLarge, FileMode.Create))
                //{
                //    if (!Directory.Exists(OriginPathLarge)) image.CopyTo(stream);
                //}



                //if (!string.IsNullOrEmpty(orginalPath))
                //{
                //    if (!Directory.Exists(orginalPath + "Small/"))
                //        Directory.CreateDirectory(orginalPath + "Small/");

                //    if (!Directory.Exists(orginalPath + "Large/"))
                //        Directory.CreateDirectory(orginalPath + "Large/");

                //    ImageOptimizer resizerorigin = new ImageOptimizer();
                //    if (widthorginsmall != null && heightorginsamll != null)
                //        resizerorigin.ImageResizer(orginalPath+fileName, OriginPathSmall, Path.GetExtension(image.FileName), widthorginsmall, heightorginsamll);

                //    if (widthorginlarge != null && heightorginlarge != null)
                //        resizerorigin.ImageResizer(orginalPath + fileName, OriginPathLarge, Path.GetExtension(image.FileName), widthorginlarge, heightorginlarge);
                //}
                //if (!string.IsNullOrEmpty(thumbPath))
                //{
                //    ImageOptimizer resizer = new ImageOptimizer();
                //    if (!Directory.Exists(thumbPath))
                //        Directory.CreateDirectory(thumbPath);

                //    resizer.ImageResizer(OriginPathLarge, thumbPath + fileName, Path.GetExtension(image.FileName), width, height);
                //}
                //File.Delete(orginalPath + fileName);
            }
        }

        public static void DeleteImage(this string imageName, string OriginPath, string ThumbPath)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                if (File.Exists(OriginPath + imageName))
                    File.Delete(OriginPath + imageName);

                if (!string.IsNullOrEmpty(ThumbPath))
                {
                    if (File.Exists(ThumbPath + imageName))
                        File.Delete(ThumbPath + imageName);
                }
            }
        }
    }
}
