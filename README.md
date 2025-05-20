# Limbo Recycle Bin

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md)
[![NuGet](https://img.shields.io/nuget/vpre/Limbo.Umbraco.RecycleBin.svg)](https://www.nuget.org/packages/Limbo.Umbraco.RecycleBin)
[![NuGet](https://img.shields.io/nuget/dt/Limbo.Umbraco.RecycleBin.svg)](https://www.nuget.org/packages/Limbo.Umbraco.RecycleBin)
[![Umbraco Marketplace](https://img.shields.io/badge/umbraco-marketplace-%233544B1)](https://marketplace.umbraco.com/package/limbo.umbraco.recyclebin)

**Limbo Recycle Bin** is an Umbraco package designed to provide enhanced control and automation for managing your content and media recycle bins. It helps keep your Umbraco installation tidy and ensures that trashed items are handled efficiently.

Key capabilities include:
- Automatically deleting content and media items from the recycle bin after they have been there for a specified number of days.
- Making media files unavailable for download as soon as they are moved to the recycle bin by renaming their physical files.

## Features

This package offers the following key features to help you manage your Umbraco recycle bin more effectively:

*   **Automatic Item Deletion:**
    *   Schedule the permanent deletion of **content items** from the recycle bin.
    *   Schedule the permanent deletion of **media items** from the recycle bin.
    *   Configure the number of days an item should remain in the recycle bin before it's automatically deleted.
*   **Secure Media Handling:**
    *   When a media item is moved to the recycle bin, its physical file is immediately renamed (by appending `.deleted`). This prevents the file from being accessed via its original URL, even if it's still in the media library's recycle bin.
    *   If a media item is restored from the recycle bin, the package attempts to rename its physical file back to the original name, making it accessible again.
*   **Configurable:**
    *   Enable or disable the cleanup functionality separately for content and media.
    *   Set different retention periods (days before deletion) for content and media items.

## How it Works

Limbo Recycle Bin integrates with Umbraco using the following mechanisms:

*   **Scheduled Background Task:** A recurring task runs periodically to check for content and media items in the recycle bin that have exceeded their configured retention period. These items are then permanently deleted.
*   **Notification Handlers:** The package listens to Umbraco's system notifications. Specifically:
    *   When a media item is moved to the recycle bin (`MediaMovedToRecycleBinNotification`), its corresponding physical file is renamed to make it inaccessible.
    *   When a media item is being permanently deleted (`MediaDeletingNotification`), the package attempts to restore the name of its physical file (if it was previously renamed). This ensures that if an item is manually restored from the recycle bin before the scheduled deletion, its file path is corrected.


## Configuration

To control the behavior of the Limbo Recycle Bin, you **must** add a `Limbo:RecycleBin` section to your `appsettings.json` file. If this section is missing, the cleanup processes may not behave as expected or could lead to errors.

Here's an example configuration:

```json
{
  "Limbo": {
    "RecycleBin": {
      "Content": {
        "Enabled": true,
        "DeleteAfterDays": 30
      },
      "Media": {
        "Enabled": true,
        "DeleteAfterDays": 30
      }
    }
  }
}
```

**Configuration Options:**

*   **`Content`**: Settings specific to content items in the recycle bin.
    *   **`Enabled`**: (Boolean) Set to `true` to enable automatic deletion of content items; `false` to disable. If not explicitly set, it's recommended to set it to `false` if you do not want content items to be deleted.
    *   **`DeleteAfterDays`**: (Integer) Specifies the number of days a content item must be in the recycle bin before it is permanently deleted by the scheduled task. Defaults to `30` if not specified, but `Enabled` must be `true` for this to take effect.

*   **`Media`**: Settings specific to media items in the recycle bin.
    *   **`Enabled`**: (Boolean) Set to `true` to enable automatic deletion of media items; `false` to disable. If not explicitly set, it's recommended to set it to `false` if you do not want media items to be deleted.
    *   **`DeleteAfterDays`**: (Integer) Specifies the number of days a media item must be in the recycle bin before it is permanently deleted by the scheduled task. Defaults to `30` if not specified, but `Enabled` must be `true` for this to take effect.

**Important:**
*   If you do not want the package to automatically delete items, ensure that `Content.Enabled` and `Media.Enabled` are both set to `false`.
*   The physical renaming of media files (appending `.deleted`) when moved to the recycle bin occurs automatically and is not controlled by these `Enabled` settings. This feature is active as long as the package is installed.

## Compatibility

This version of Limbo.Umbraco.RecycleBin (NuGet package version 13.x.x) is specifically for **Umbraco 13**.

For older versions of Umbraco:
*   **Umbraco 10, 11, and 12:** Please use version 1.x.x of this package, which can be found on the [**v1/main**](https://github.com/limbo-works/Limbo.Umbraco.RecycleBin/tree/v1/main) branch and corresponding NuGet releases.


## Installation

This package (version 13.x.x) is for **Umbraco 13** and is only available via [**NuGet**](https://www.nuget.org/packages/Limbo.Umbraco.RecycleBin/13.0.0). To install the package, you can use either .NET CLI:

```
dotnet add package Limbo.Umbraco.RecycleBin --version 13.0.0
```

or the older NuGet Package Manager:

```
Install-Package Limbo.Umbraco.RecycleBin -Version 13.0.0
```

## Contributing

Contributions to Limbo.Umbraco.RecycleBin are welcome! If you find a bug, have a feature request, or want to improve the package, please feel free to:

*   Fork the repository on [GitHub](https://github.com/limbo-works/Limbo.Umbraco.RecycleBin/).
*   Create a new branch for your changes.
*   Submit a pull request with a clear description of your changes.
*   Report issues or suggest features via the [GitHub Issues page](https://github.com/limbo-works/Limbo.Umbraco.RecycleBin/issues).


## License

This package is released under the [MIT License](LICENSE.md). This means you are free to use, modify, and distribute it, even for commercial purposes, as long as you include the original copyright and license notice.


## Support and Issues

If you encounter any problems or have questions regarding the Limbo Recycle Bin package, please raise an issue on the [GitHub Issues page](https://github.com/limbo-works/Limbo.Umbraco.RecycleBin/issues).
