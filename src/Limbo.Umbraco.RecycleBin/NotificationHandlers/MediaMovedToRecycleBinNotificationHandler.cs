using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Limbo.Umbraco.RecycleBin.NotificationHandlers {
    public class MediaMovedToRecycleBinNotificationHandler : INotificationHandler<MediaMovedToRecycleBinNotification> {

        private readonly ILogger<MediaMovedToRecycleBinNotificationHandler> _logger;

        public MediaMovedToRecycleBinNotificationHandler(ILogger<MediaMovedToRecycleBinNotificationHandler> logger) {
            _logger = logger;
        }

        public void Handle(MediaMovedToRecycleBinNotification notification) {
            foreach (var mediaItem in notification.MoveInfoCollection) {
                _logger.LogInformation(mediaItem.Entity.Id.ToString());
            }
        }

    }
}
