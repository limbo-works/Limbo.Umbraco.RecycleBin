using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Limbo.Umbraco.RecycleBin.NotificationHandlers {
    public class MediaMovingToRecycleBinNotificationHandler : INotificationHandler<MediaMovingToRecycleBinNotification> {

        private readonly ILogger<MediaMovingToRecycleBinNotificationHandler> _logger;

        public MediaMovingToRecycleBinNotificationHandler(ILogger<MediaMovingToRecycleBinNotificationHandler> logger) {
            _logger = logger;
        }

        public void Handle(MediaMovingToRecycleBinNotification notification) {
            foreach (var mediaItem in notification.MoveInfoCollection) {
                _logger.LogInformation(mediaItem.Entity.Id.ToString());
            }
        }

    }
}
