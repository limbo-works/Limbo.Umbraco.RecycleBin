# Limbo.Umbraco.RecycleBin

**Limbo RecycleBin** helps you handle your Umbraco Recycle Bin.

- It automatically deletes items in the recycle bin that were deleted x days ago. Both content og media.
- It physical moves trashed items so that they are not available to download.


## Configuration

To configure the package, add a `Limbo:RecycleBin` section to your `appsettings.json` like in the example below:

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
