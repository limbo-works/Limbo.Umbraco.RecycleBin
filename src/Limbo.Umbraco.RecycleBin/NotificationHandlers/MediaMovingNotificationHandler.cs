using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Limbo.Umbraco.RecycleBin.NotificationHandlers {
    public class MediaMovingNotificationHandler : INotificationHandler<MediaMovingNotification> {

        private readonly ILogger<MediaMovingNotificationHandler> _logger;

        public MediaMovingNotificationHandler(ILogger<MediaMovingNotificationHandler> logger) {
            _logger = logger;
        }

        public void Handle(MediaMovingNotification notification) {
            foreach (var mediaItem in notification.MoveInfoCollection) {
                _logger.LogInformation("Moving " + mediaItem.Entity.Id.ToString());
            }
        }

    }
}
