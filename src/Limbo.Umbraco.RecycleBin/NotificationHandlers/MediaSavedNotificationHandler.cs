using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Limbo.Umbraco.RecycleBin.NotificationHandlers {
    public class MediaSavedNotificationHandler : INotificationHandler<MediaSavedNotification> {

        private readonly ILogger<MediaSavedNotificationHandler> _logger;

        public MediaSavedNotificationHandler(ILogger<MediaSavedNotificationHandler> logger) {
            _logger = logger;
        }

        public void Handle(MediaSavedNotification notification) {
            foreach (var mediaItem in notification.SavedEntities) {
                _logger.LogInformation("Saved " + mediaItem.Id.ToString());
            }
        }

    }
}
