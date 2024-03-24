using Limbo.Umbraco.RecycleBin.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Limbo.Umbraco.RecycleBin.Services {
    public class CleanUpService {

        private readonly ILogger<CleanUpService> _logger;
        private readonly IContentService _contentService;
        private readonly IMediaService _mediaService;
        private readonly IOptions<CleanUpSettingsRecycleBin> _cleanUpSettingsRecycleBin;

        public CleanUpService(ILogger<CleanUpService> logger, IContentService contentService, IMediaService mediaService, IOptions<CleanUpSettingsRecycleBin> cleanUpSettingsRecycleBin) {
            _logger = logger;
            _contentService = contentService;
            _mediaService = mediaService;
            _cleanUpSettingsRecycleBin = cleanUpSettingsRecycleBin;
        }

        internal void CleanUpContent() {

            try {

                if (!_cleanUpSettingsRecycleBin.Value.Content.Enabled) {
                    return;
                }

                if (!_contentService.RecycleBinSmells()) {
                    return;
                }

                IEnumerable<IContent> items = _contentService.GetPagedContentInRecycleBin(0, int.MaxValue, out long totalRecords);
                foreach (IContent item in items) {
                    if ((DateTime.Now - item.UpdateDate).Days >= _cleanUpSettingsRecycleBin.Value.Content.DeleteAfterDays) {
                        try {
                            _logger.LogInformation("Permanently deleting content: " + item.Name + " " + item.Key.ToString());
                            _contentService.Delete(item);
                        } catch {
                        }
                    }
                }

            } catch {
            }

        }

        internal void CleanUpMedia() {

            try {

                if (!_cleanUpSettingsRecycleBin.Value.Media.Enabled) {
                    return;
                }

                if (!_mediaService.RecycleBinSmells()) {
                    return;
                }

                IEnumerable<IMedia> items = _mediaService.GetPagedMediaInRecycleBin(0, int.MaxValue, out long totalRecords);
                foreach (IMedia item in items) {
                    if ((DateTime.Now - item.UpdateDate).Days >= _cleanUpSettingsRecycleBin.Value.Media.DeleteAfterDays) {
                        try {
                            _logger.LogInformation("Permanently deleting media: " + item.Name + " " + item.Key.ToString());
                            _mediaService.Delete(item);
                        } catch {
                        }
                    }
                }

            } catch {
            }

        }
    }
}
