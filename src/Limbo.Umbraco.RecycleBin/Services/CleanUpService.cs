using Microsoft.Extensions.Logging;

namespace Limbo.Umbraco.RecycleBin.Services {
    public class CleanUpService {

        private readonly ILogger<CleanUpService> _logger;

        public CleanUpService(ILogger<CleanUpService> logger) {
            _logger = logger;
        }

        internal void CleanUpContent() {
            _logger.LogInformation("CleanUpContent");
        }

        internal void CleanUpMedia() {
            _logger.LogInformation("CleanUpMedia");
        }
    }
}
