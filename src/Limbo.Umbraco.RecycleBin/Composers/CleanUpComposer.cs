using Limbo.Umbraco.RecycleBin.Manifests;
using Limbo.Umbraco.RecycleBin.Models.Settings;
using Limbo.Umbraco.RecycleBin.Scheduling;
using Limbo.Umbraco.RecycleBin.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skybrud.Essentials.Configuration;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Hosting;
using Umbraco.Cms.Infrastructure.Manifest;
using Umbraco.Extensions;


namespace Limbo.Umbraco.RecycleBin.Composers;

public class CleanUpComposer : IComposer {

    public void Compose(IUmbracoBuilder builder) {
        builder.Services.AddSingleton<IPackageManifestReader, RecycleBinPackageManifestReader>();
        builder.Services.AddOptions<RecycleBinSettings>().Configure<IConfiguration, IHostingEnvironment>(ConfigureBinder);
        builder.Services.AddSingleton<RecycleBinService>();
        builder.Services.AddRecurringBackgroundJob<CleanUpTask>();
    }

    private void ConfigureBinder(RecycleBinSettings settings, IConfiguration configuration, IHostingEnvironment hostingEnvironment) {
        ConfigureContent(settings, configuration);
        ConfigureMedia(settings, configuration);
    }

    private static void ConfigureContent(RecycleBinSettings settings, IConfiguration configuration) {

        IConfigurationSection section = configuration.GetSection("Limbo:RecycleBin:Content");

        if (section.TryGetBoolean("Enabled", out bool enabled)) {
            settings.Content.Enabled = enabled;
        }

        if (section.TryGetInt32("DeleteAfterDays", out int deleteAfterDays) && deleteAfterDays > 0) {
            settings.Content.DeleteAfterDays = deleteAfterDays;
        }

    }

    private static void ConfigureMedia(RecycleBinSettings settings, IConfiguration configuration) {

        IConfigurationSection section = configuration.GetSection("Limbo:RecycleBin:Media");

        if (section.TryGetBoolean("Enabled", out bool enabled)) {
            settings.Media.Enabled = enabled;
        }

        if (section.TryGetInt32("DeleteAfterDays", out int deleteAfterDays) && deleteAfterDays > 0) {
            settings.Media.DeleteAfterDays = deleteAfterDays;
        }

    }

}