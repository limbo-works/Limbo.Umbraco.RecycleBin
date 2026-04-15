using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Sync;
using Umbraco.Cms.Infrastructure.BackgroundJobs;
using Limbo.Umbraco.RecycleBin.Services;

namespace Limbo.Umbraco.RecycleBin.Scheduling {

    public class CleanUpTask : IRecurringBackgroundJob {

        private readonly IRuntimeState _runtimeState;
        private readonly ILogger<CleanUpTask> _logger;
        private readonly CleanUpService _cleanUpService;

        public TimeSpan Period => TimeSpan.FromMinutes(60);

        public TimeSpan Delay => TimeSpan.FromMinutes(10);

        public ServerRole[] ServerRoles => new[] { ServerRole.SchedulingPublisher, ServerRole.Single };

        public event EventHandler PeriodChanged { add { } remove { } }

        public CleanUpTask(IRuntimeState runtimeState, ILogger<CleanUpTask> logger, CleanUpService cleanUpService) {
            _runtimeState = runtimeState;
            _logger = logger;
            _cleanUpService = cleanUpService;
        }

        public Task RunJobAsync() {

            // Don't do anything if the site is not fully running yet.
            if (_runtimeState.Level != RuntimeLevel.Run) {
                return Task.CompletedTask;
            }

            try {
                _cleanUpService.CleanUpContent();
                _cleanUpService.CleanUpMedia();
            } catch (Exception ex) {
                _logger.LogError(ex, "CleanUp failed.");
            }

            return Task.CompletedTask;
        }

    }
}
