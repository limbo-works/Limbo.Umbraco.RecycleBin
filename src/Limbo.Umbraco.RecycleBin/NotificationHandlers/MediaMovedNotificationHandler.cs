using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Nodes;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace Limbo.Umbraco.RecycleBin.NotificationHandlers;

public class MediaMovedNotificationHandler : INotificationHandler<MediaMovedNotification> {

    private readonly ILogger<MediaMovedNotificationHandler> _logger;
    private readonly MediaFileManager _mediaFileManager;

    public MediaMovedNotificationHandler(ILogger<MediaMovedNotificationHandler> logger, MediaFileManager mediaFileManager) {
        _logger = logger;
        _mediaFileManager = mediaFileManager;
    }

    public void Handle(MediaMovedNotification notification) {
        foreach (MoveEventInfo<IMedia> mediaItem in notification.MoveInfoCollection) {

            try {

                string? filePath = mediaItem.Entity.GetValue<string>("umbracoFile");
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