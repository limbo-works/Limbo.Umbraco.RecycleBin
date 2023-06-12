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
            builder.Services.AddOptions<CleanUpSettingsRecycleBin>().Configure<IConfiguration, IHostingEnvironment>(ConfigureBinder);
            builder.Services.AddSingleton<CleanUpService>();
            builder.Services.AddHostedService<CleanUpTask>();
        }

        private void ConfigureBinder(CleanUpSettingsRecycleBin cleanUpSettingsRecycleBin, IConfiguration configuration, IHostingEnvironment hostingEnvironment) {

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

            CleanUpSettings cleanUpSettingsContent = new CleanUpSettings();
            cleanUpSettingsContent.Enabled = contentEnabledBool;
            cleanUpSettingsContent.DeleteAfterDays = contentDeleteAfterDaysInt;
            cleanUpSettingsRecycleBin.Content = cleanUpSettingsContent;


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

            CleanUpSettings cleanUpSettingsMedia = new CleanUpSettings();
            cleanUpSettingsMedia.Enabled = mediaEnabledBool;
            cleanUpSettingsMedia.DeleteAfterDays = mediaDeleteAfterDaysInt;
            cleanUpSettingsRecycleBin.Media = cleanUpSettingsMedia;

        }
    }
}
