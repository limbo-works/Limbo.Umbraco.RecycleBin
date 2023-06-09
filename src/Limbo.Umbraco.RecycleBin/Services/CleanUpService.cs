using Limbo.Umbraco.RecycleBin.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Limbo.Umbraco.RecycleBin.Services {
    public class CleanUpService {

        private readonly ILogger<CleanUpService> _logger;
        private readonly IContentService _contentService;
        private readonly IOptions<CleanUpSettingRecycleBin> _cleanUpSettingRecycleBin;

        public CleanUpService(ILogger<CleanUpService> logger, IContentService contentService, IOptions<CleanUpSettingRecycleBin> cleanUpSettingRecycleBin) {
            _logger = logger;
            _contentService = contentService;
            _cleanUpSettingRecycleBin = cleanUpSettingRecycleBin;
        }

        internal void CleanUpContent() {

            try {

                _logger.LogInformation("CleanUpContent Begin1");

                if (!_cleanUpSettingRecycleBin.Value.Content.Enabled) {
                    return;
                }

                _logger.LogInformation("CleanUpContent Begin2");

                if (!_contentService.RecycleBinSmells()) {
                    return;
                }

                IEnumerable<IContent> items = _contentService.GetPagedContentInRecycleBin(0, int.MaxValue, out long totalRecords);
                foreach (IContent item in items) {
                    if ((DateTime.Now - item.UpdateDate).Days > _cleanUpSettingRecycleBin.Value.Content.DeleteAfterDays) {
                        try {
                            _logger.LogInformation("Deleted: " + item.Name);
                            _contentService.Delete(item);
                        } catch {
                        }
                    }
                }

            } catch {
            }

        }

        internal void CleanUpMedia() {
            _logger.LogInformation("CleanUpMedia Begin");
            _logger.LogInformation("CleanUpMedia End");
        }
    }
}
