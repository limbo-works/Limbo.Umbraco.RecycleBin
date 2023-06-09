using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Limbo.Umbraco.RecycleBin.Services {
    public class CleanUpService {

        private readonly ILogger<CleanUpService> _logger;
        private readonly IContentService _contentService;

        public CleanUpService(ILogger<CleanUpService> logger, IContentService contentService) {
            _logger = logger;
            _contentService = contentService;
        }

        internal void CleanUpContent() {
            _logger.LogInformation("CleanUpContent Begin");

            try {
                if (!_contentService.RecycleBinSmells()) {
                    return;
                }

                IEnumerable<IContent> items = _contentService.GetPagedContentInRecycleBin(0, int.MaxValue, out long totalRecords);
                foreach (IContent item in items) {
                    if ((DateTime.Now - item.UpdateDate).Days > 14) {
                        try {
                            _logger.LogInformation("Deleted: " + item.Name);
                            _contentService.Delete(item);
                        } catch {
                        }
                    }
                }
            } catch {
            }

            _logger.LogInformation("CleanUpContent End");
        }

        internal void CleanUpMedia() {
            _logger.LogInformation("CleanUpMedia Begin");
            _logger.LogInformation("CleanUpMedia End");
        }
    }
}
