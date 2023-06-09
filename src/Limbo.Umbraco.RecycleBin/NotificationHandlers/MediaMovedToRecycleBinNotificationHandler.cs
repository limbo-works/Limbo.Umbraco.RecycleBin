using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace Limbo.Umbraco.RecycleBin.NotificationHandlers {
    public class MediaMovedToRecycleBinNotificationHandler : INotificationHandler<MediaMovedToRecycleBinNotification> {

        private readonly ILogger<MediaMovedToRecycleBinNotificationHandler> _logger;
        private readonly MediaFileManager _mediaFileManager;

        public MediaMovedToRecycleBinNotificationHandler(ILogger<MediaMovedToRecycleBinNotificationHandler> logger, MediaFileManager mediaFileManager) {
            _logger = logger;
            _mediaFileManager = mediaFileManager;
        }

        public void Handle(MediaMovedToRecycleBinNotification notification) {
            foreach (var mediaItem in notification.MoveInfoCollection) {

                try {

                    var filePath = mediaItem.Entity.GetValue<string>("umbracoFile");
                    if (filePath == null) {
                        return;
                    }

                    var fileExists = _mediaFileManager.FileSystem.FileExists(filePath);
                    if (!fileExists) {
                        return;
                    }

                    _mediaFileManager.FileSystem.CopyFile(filePath, filePath + ".deleted");
                    _mediaFileManager.FileSystem.DeleteFile(filePath);

                } catch {

                }

            }
        }

    }
}
