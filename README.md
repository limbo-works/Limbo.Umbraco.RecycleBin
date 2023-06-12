# Limbo.Umbraco.RecycleBin

**Limbo RecycleBin** helps you handle your Umbraco Recycle Bin.

- It automatically deletes items in the recycle bin that were deleted x days ago. Both content og media.
- It physical moves trashed media items so that they are not available to download.


## Installation

This package is available for Umbraco 10+ via NuGet. To install the package, you can use either .NET CLI:

```
dotnet add package Limbo.Umbraco.RecycleBin --version 1.0.2
```

or the older NuGet Package Manager:

```
Install-Package Limbo.Umbraco.RecycleBin -Version 1.0.2
```


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
