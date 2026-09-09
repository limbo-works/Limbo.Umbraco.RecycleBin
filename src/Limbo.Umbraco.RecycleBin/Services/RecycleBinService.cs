using Limbo.Umbraco.RecycleBin.Models.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Limbo.Umbraco.RecycleBin.Services;

public class RecycleBinService {

    private readonly ILogger<RecycleBinService> _logger;
    private readonly IContentService _contentService;
    private readonly IMediaService _mediaService;
    private readonly IOptions<RecycleBinSettings> _cleanUpSettingsRecycleBin;

    public RecycleBinService(ILogger<RecycleBinService> logger, IContentService contentService, IMediaService mediaService, IOptions<RecycleBinSettings> cleanUpSettingsRecycleBin) {
        _logger = logger;
        _contentService = contentService;
        _mediaService = mediaService;
        _cleanUpSettingsRecycleBin = cleanUpSettingsRecycleBin;
    }

    internal void CleanUpContent() {

        try {

            if (!_cleanUpSettingsRecycleBin.Value.Content.Enabled) {
                return;
            }

            if (!_contentService.RecycleBinSmells()) {
                return;
            }

            IEnumerable<IContent> items = _contentService.GetPagedContentInRecycleBin(0, int.MaxValue, out long _);
            foreach (IContent item in items) {
                if ((DateTime.Now - item.UpdateDate).Days >= _cleanUpSettingsRecycleBin.Value.Content.DeleteAfterDays) {
                    try {
                        _logger.LogInformation("Permanently deleting content: {Name} {Key}", item.Name, item.Key);
                        _contentService.Delete(item);
                    } catch {
                        // should we really ignore this? maybe log it as a warning or error?
                    }
                }
            }

        } catch {
            // should we really ignore this? maybe log it as a warning or error?
        }

    }

    internal void CleanUpMedia() {

        try {

            if (!_cleanUpSettingsRecycleBin.Value.Media.Enabled) {
                return;
            }

            if (!_mediaService.RecycleBinSmells()) {
                return;
            }

            IEnumerable<IMedia> items = _mediaService.GetPagedMediaInRecycleBin(0, int.MaxValue, out long _);
            foreach (IMedia item in items) {
                if ((DateTime.Now - item.UpdateDate).Days >= _cleanUpSettingsRecycleBin.Value.Media.DeleteAfterDays) {
                    try {
                        _logger.LogInformation("Permanently deleting media: {Name} {Key}", item.Name, item.Key);
                        _mediaService.Delete(item);
                    } catch {
                        // should we really ignore this? maybe log it as a warning or error?
                    }
                }
            }

        } catch {
            // should we really ignore this? maybe log it as a warning or error?
        }

    }

}