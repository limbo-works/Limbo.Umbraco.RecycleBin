using Limbo.Umbraco.RecycleBin.NotificationHandlers;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Limbo.Umbraco.RecycleBin.Composers {
    public class NotificationHandlerComposer : IComposer {

        public void Compose(IUmbracoBuilder builder) {
            builder.AddNotificationHandler<MediaSavingNotification, MediaSavingNotificationHandler>();
            builder.AddNotificationHandler<MediaSavedNotification, MediaSavedNotificationHandler>();
            builder.AddNotificationHandler<MediaMovingToRecycleBinNotification, MediaMovingToRecycleBinNotificationHandler>();
            builder.AddNotificationHandler<MediaMovedToRecycleBinNotification, MediaMovedToRecycleBinNotificationHandler>();
        }

    }
}
