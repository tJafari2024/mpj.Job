using Microsoft.Extensions.Configuration;
using static Mpj.Web.Utils.ConfigHandler;

namespace Mpj.Web.Utils
{
    public static class ConfigHandler
    {
        #region FileSetting
        public static FileSetting GeFileSetting()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            FileSetting fileSetting = new FileSetting();
            configuration.Bind("FileSetting", fileSetting);

            return fileSetting;
        }
        public class FileSetting
        {
            public string FileSize { get; set; }
            public string FileFormat { get; set; }

        }
        #endregion
        #region ImageSetting
        public class ImageSetting
        {
            public string ImageSize { get; set; }
            public string ImageFormat { get; set; }
            public string ImageW_H { get; set; }

        }
        public static ImageSetting GeImageSetting()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            ImageSetting imageSetting = new ImageSetting();
            configuration.Bind("ImageSetting", imageSetting);

            return imageSetting;
        }
        #endregion
        #region SatisfactionRules
        public class SatisfactionRules
        {
            public string Rule { get; set; }


        }
        public static SatisfactionRules GeRuleSetting()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            SatisfactionRules rule = new SatisfactionRules();
            configuration.Bind("SatisfactionRules", rule);

            return rule;
        }
        #endregion
        #region SMSSetting
        public class SMSSetting
        {
            public string SenderNumber { get; set; }
            public string api_key { get; set; }
            public string MessageForAuth { get; set; }
            public string MessageForTrackingCode { get; set; }

        }
        public static SMSSetting GetSMSSetting()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            SMSSetting smsSetting = new SMSSetting();
            configuration.Bind("SMSSetting", smsSetting);

            return smsSetting;
        }


        #endregion
    }
}
