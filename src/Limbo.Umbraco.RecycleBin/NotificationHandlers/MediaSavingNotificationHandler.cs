using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Limbo.Umbraco.RecycleBin.NotificationHandlers {
    public class MediaSavingNotificationHandler : INotificationHandler<MediaSavingNotification> {

        private readonly ILogger<MediaSavingNotificationHandler> _logger;

        public MediaSavingNotificationHandler(ILogger<MediaSavingNotificationHandler> logger) {
            _logger = logger;
        }

        public void Handle(MediaSavingNotification notification) {
            foreach (var mediaItem in notification.SavedEntities) {
                _logger.LogInformation(mediaItem.Id.ToString());
            }
        }

    }
}
