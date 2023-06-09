using Limbo.Umbraco.RecycleBin.Scheduling;
using Limbo.Umbraco.RecycleBin.Services;
using Limbo.Umbraco.RecycleBin.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Hosting;

namespace Limbo.Umbraco.RecycleBin.Composers {
    public class CleanUpComposer : IComposer {
        public void Compose(IUmbracoBuilder builder) {
            builder.Services.AddOptions<CleanUpSettingRecycleBin>().Configure<IConfiguration, IHostingEnvironment>(ConfigureBinder);
            builder.Services.AddSingleton<CleanUpService>();
            builder.Services.AddHostedService<CleanUpTask>();
        }

        private void ConfigureBinder(CleanUpSettingRecycleBin cleanUpSettingRecycleBin, IConfiguration configuration, IHostingEnvironment hostingEnvironment) {

            var limboRecycleBinContentSection = configuration.GetSection("Limbo:RecycleBin:Content");
            var limboRecycleBinMediaSection = configuration.GetSection("Limbo:RecycleBin:Media");


            var contentEnabled = limboRecycleBinContentSection?.GetSection("Enabled")?.Value;
            bool contentEnabledBool = false;
            if (!string.IsNullOrWhiteSpace(contentEnabled)) {
                bool.TryParse(contentEnabled, out contentEnabledBool);
            }

            var contentDeleteAfterDays = limboRecycleBinContentSection?.GetSection("DeleteAfterDays")?.Value;
            int contentDeleteAfterDaysInt = 30;
            if (!string.IsNullOrWhiteSpace(contentDeleteAfterDays)) {
                int.TryParse(contentDeleteAfterDays, out contentDeleteAfterDaysInt);
            }

            CleanUpSetting cleanUpSettingContent = new CleanUpSetting();
            cleanUpSettingContent.Enabled = contentEnabledBool;
            cleanUpSettingContent.DeleteAfterDays = contentDeleteAfterDaysInt;
            cleanUpSettingRecycleBin.Content = cleanUpSettingContent;


            var mediaEnabled = limboRecycleBinMediaSection?.GetSection("Enabled")?.Value;
            bool mediaEnabledBool = false;
            if (!string.IsNullOrWhiteSpace(mediaEnabled)) {
                bool.TryParse(mediaEnabled, out mediaEnabledBool);
            }

            var mediaDeleteAfterDays = limboRecycleBinMediaSection?.GetSection("DeleteAfterDays")?.Value;
            int mediaDeleteAfterDaysInt = 30;
            if (!string.IsNullOrWhiteSpace(mediaDeleteAfterDays)) {
                int.TryParse(mediaDeleteAfterDays, out mediaDeleteAfterDaysInt);
            }

            CleanUpSetting cleanUpSettingMedia = new CleanUpSetting();
            cleanUpSettingMedia.Enabled = mediaEnabledBool;
            cleanUpSettingMedia.DeleteAfterDays = mediaDeleteAfterDaysInt;
            cleanUpSettingRecycleBin.Media = cleanUpSettingMedia;

        }
    }
}
