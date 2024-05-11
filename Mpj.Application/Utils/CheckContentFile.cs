using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;


namespace Mpj.Application.Utils
{
    public static class CheckContentFile
    {
        public const int FileMinimumBytes = 512;

        public static bool IsPdf(this IFormFile postedFile)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (postedFile.ContentType.ToLower() != "application/pdf")
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            if (Path.GetExtension(postedFile.FileName).ToLower() != ".pdf")
            {
                return false;
            }
            
            //-------------------------------------------
            //  Attempt to read the file and check the first bytes
            //-------------------------------------------
            try
            {
                if (!postedFile.OpenReadStream().CanRead)
                {
                    return false;
                }
                //------------------------------------------
                //check whether the image size exceeding the limit or not
                //------------------------------------------ 
                if (postedFile.Length < FileMinimumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[FileMinimumBytes];
                postedFile.OpenReadStream().Read(buffer, 0, FileMinimumBytes);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }


            return true;
        }
        
    }
}
