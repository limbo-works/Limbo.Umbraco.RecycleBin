using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Limbo.Umbraco.RecycleBin.NotificationHandlers {
    public class MediaDeletingNotificationHandler : INotificationHandler<MediaDeletingNotification> {

        private readonly ILogger<MediaDeletingNotificationHandler> _logger;

        public MediaDeletingNotificationHandler(ILogger<MediaDeletingNotificationHandler> logger) {
            _logger = logger;
        }

        public void Handle(MediaDeletingNotification notification) {
            foreach (var mediaItem in notification.DeletedEntities) {
                _logger.LogInformation("Deleting " + mediaItem.Id.ToString());
            }
        }

    }
}
