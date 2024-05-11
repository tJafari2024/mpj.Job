
namespace Mpj.Application.Utils
{
    public static class PathExtension
    {
        #region PersonalImage

       
        public static string PersonalImageOrigin= "/content/PersonalImage/";
        public static string DocumentFileOrigin = "/content/DocumentFile/";
        public static string PersonalImageOriginSmall = "/content/PersonalImage/origin/Small/";
        public static string ResumeFileOrigin = "/content/ResumeFile/";
        public static string ResumeFileServerOrigin = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//content/ResumeFile/");
        public static string DocumentFileServerOrigin = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//content/DocumentFile/");
        public static string PersonalImageServerOrigin = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//content/PersonalImage/");

        #endregion
    }

}
