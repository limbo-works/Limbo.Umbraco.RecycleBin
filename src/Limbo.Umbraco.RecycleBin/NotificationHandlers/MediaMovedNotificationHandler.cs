﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace Limbo.Umbraco.RecycleBin.NotificationHandlers {
    public class MediaMovedNotificationHandler : INotificationHandler<MediaMovedNotification> {

        private readonly ILogger<MediaMovedNotificationHandler> _logger;
        private readonly MediaFileManager _mediaFileManager;

        public MediaMovedNotificationHandler(ILogger<MediaMovedNotificationHandler> logger, MediaFileManager mediaFileManager) {
            _logger = logger;
            _mediaFileManager = mediaFileManager;
        }

        public void Handle(MediaMovedNotification notification) {
            foreach (var mediaItem in notification.MoveInfoCollection) {

                try {

                    var filePath = mediaItem.Entity.GetValue<string>("umbracoFile");
                    if (filePath == null) {
                        return;
                    }

                    try {
                        dynamic data = JObject.Parse(filePath);
                        filePath = Convert.ToString(data.src);
                    } catch {
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
