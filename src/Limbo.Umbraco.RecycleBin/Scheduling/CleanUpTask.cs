using Umbraco.Cms.Infrastructure.HostedServices;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Sync;
using Limbo.Umbraco.RecycleBin.Services;

namespace Limbo.Umbraco.RecycleBin.Scheduling
{
    public class CleanUpTask : RecurringHostedServiceBase {

        private readonly IRuntimeState _runtimeState;
        private readonly IServerRoleAccessor _serverRoleAccessor;
        private readonly ILogger<CleanUpTask> _logger;
        private readonly CleanUpService _cleanUpService;

        private static TimeSpan Period => TimeSpan.FromMinutes(1);
        private static TimeSpan Delay => TimeSpan.FromMinutes(1);

        public CleanUpTask(IRuntimeState runtimeState, IServerRoleAccessor serverRoleAccessor, ILogger<CleanUpTask> logger, CleanUpService cleanUpService) : base(logger, Period, Delay) {
            _runtimeState = runtimeState;
            _serverRoleAccessor = serverRoleAccessor;
            _logger = logger;
            _cleanUpService = cleanUpService;
        }

        public override Task PerformExecuteAsync(object? state) {

            // Don't do anything if the site is not running.
            if (_runtimeState.Level != RuntimeLevel.Run) {
                _logger.LogInformation("Not running");
                return Task.CompletedTask;
            }

            // Do not run the code on subscribers or unknown role servers
            // ONLY run for SchedulingPublisher server or Single server roles
            switch (_serverRoleAccessor.CurrentServerRole) {
                case ServerRole.Subscriber:
                    _logger.LogInformation("Not running - Subscriber");
                    return Task.CompletedTask; // We return Task.CompletedTask to try again as the server role may change!
                case ServerRole.Unknown:
                    _logger.LogInformation("Not running - Unknown");
                    return Task.CompletedTask; // We return Task.CompletedTask to try again as the server role may change! 
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
