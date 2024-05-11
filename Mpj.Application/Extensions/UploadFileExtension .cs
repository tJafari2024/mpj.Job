
using Microsoft.AspNetCore.Http;
using Mpj.Application.Utils;

namespace Mpj.Application.Extensions
{
    public static class UploadFileExtension
    {
        public static void AddFileToServer(this IFormFile file, string fileName, string orginalPath, string deletefileName = null)
        {
            if (file != null && file.IsPdf())
            {
                if (!Directory.Exists(orginalPath))
                    Directory.CreateDirectory(orginalPath);

                if (!string.IsNullOrEmpty(deletefileName))
                {
                    if (File.Exists(orginalPath + deletefileName))
                        File.Delete(orginalPath + deletefileName);

                  
                }

                
                using (var stream = new FileStream(orginalPath + fileName, FileMode.Create))
                {
                    if (!Directory.Exists(orginalPath + fileName)) file.CopyTo(stream);
                }
          
            }
        }

        public static void DeleteFile(this string fileName, string OriginPath)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                if (File.Exists(OriginPath + fileName))
                    File.Delete(OriginPath + fileName);

                
            }
        }
    }
}
