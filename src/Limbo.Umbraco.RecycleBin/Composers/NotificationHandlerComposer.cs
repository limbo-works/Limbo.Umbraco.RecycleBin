using Limbo.Umbraco.RecycleBin.NotificationHandlers;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Limbo.Umbraco.RecycleBin.Composers {
    public class NotificationHandlerComposer : IComposer {

        public void Compose(IUmbracoBuilder builder) {
            builder.AddNotificationHandler<MediaMovingNotification, MediaMovingNotificationHandler>();
            builder.AddNotificationHandler<MediaMovedNotification, MediaMovedNotificationHandler>();
            builder.AddNotificationHandler<MediaMovingToRecycleBinNotification, MediaMovingToRecycleBinNotificationHandler>();
            builder.AddNotificationHandler<MediaMovedToRecycleBinNotification, MediaMovedToRecycleBinNotificationHandler>();
            builder.AddNotificationHandler<MediaDeletingNotification, MediaDeletingNotificationHandler>();
            builder.AddNotificationHandler<MediaDeletedNotification, MediaDeletedNotificationHandler>();
        }

    }
}
