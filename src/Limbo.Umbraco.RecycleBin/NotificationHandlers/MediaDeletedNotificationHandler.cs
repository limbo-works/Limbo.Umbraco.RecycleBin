using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Limbo.Umbraco.RecycleBin.NotificationHandlers {
    public class MediaDeletedNotificationHandler : INotificationHandler<MediaDeletedNotification> {

        private readonly ILogger<MediaDeletedNotificationHandler> _logger;

        public MediaDeletedNotificationHandler(ILogger<MediaDeletedNotificationHandler> logger) {
            _logger = logger;
        }

        public void Handle(MediaDeletedNotification notification) {
            foreach (var mediaItem in notification.DeletedEntities) {
                _logger.LogInformation("Deleted " + mediaItem.Id.ToString());
            }
        }

    }
}
