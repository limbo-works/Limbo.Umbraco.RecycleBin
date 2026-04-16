using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Nodes;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Models;
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
            foreach (IMedia mediaItem in notification.DeletedEntities) {

                try {

                    string? filePath = mediaItem.GetValue<string>("umbracoFile");
                    if (filePath == null) {
                        return;
                    }

                    if (filePath.TrimStart().StartsWith('{')) {
                        try {
                            JsonNode? node = JsonNode.Parse(filePath);
                            string? src = node?["src"]?.GetValue<string>();
                            if (!string.IsNullOrEmpty(src)) {
                                filePath = src;
                            }
                        } catch (JsonException) {
                        }
                    }

                    bool fileExists = _mediaFileManager.FileSystem.FileExists(filePath + ".deleted");
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
