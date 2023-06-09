using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Limbo.Umbraco.RecycleBin.NotificationHandlers {
    public class MediaMovedNotificationHandler : INotificationHandler<MediaMovedNotification> {

        private readonly ILogger<MediaMovedNotificationHandler> _logger;

        public MediaMovedNotificationHandler(ILogger<MediaMovedNotificationHandler> logger) {
            _logger = logger;
        }

        public void Handle(MediaMovedNotification notification) {
            foreach (var mediaItem in notification.MoveInfoCollection) {
                _logger.LogInformation("Moved " + mediaItem.Entity.Id.ToString());
            }
        }

    }
}
