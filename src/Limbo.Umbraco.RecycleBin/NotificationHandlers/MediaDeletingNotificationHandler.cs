using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace Limbo.Umbraco.RecycleBin.NotificationHandlers {
    public class MediaDeletingNotificationHandler : INotificationHandler<MediaDeletingNotification> {

        private readonly ILogger<MediaDeletingNotificationHandler> _logger;
        private readonly MediaFileManager _mediaFileManager;

        public MediaDeletingNotificationHandler(ILogger<MediaDeletingNotificationHandler> logger, MediaFileManager mediaFileManager) {
            _logger = logger;
            _mediaFileManager = mediaFileManager;
        }

        public void Handle(MediaDeletingNotification notification) {
            foreach (var mediaItem in notification.DeletedEntities) {

                _logger.LogInformation("Deleting " + mediaItem.Id.ToString());

                try {

                    var filePath = mediaItem.GetValue<string>("umbracoFile");
                    if (filePath == null) {
                        return;
                    }

                    var fileExists = _mediaFileManager.FileSystem.FileExists(filePath + ".deleted");
                    if (!fileExists) {
                        return;
                    }

                    _mediaFileManager.FileSystem.CopyFile(filePath + ".deleted", filePath);
                    _mediaFileManager.FileSystem.DeleteFile(filePath + ".deleted");

                } catch {

                }

            }
        }

    }
}
