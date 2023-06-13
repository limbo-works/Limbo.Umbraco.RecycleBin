# Limbo Recycle Bin [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md) [![NuGet](https://img.shields.io/nuget/vpre/Limbo.Umbraco.RecycleBin.svg)](https://www.nuget.org/packages/Limbo.Umbraco.RecycleBin) [![NuGet](https://img.shields.io/nuget/dt/Limbo.Umbraco.RecycleBin.svg)](https://www.nuget.org/packages/Limbo.Umbraco.RecycleBin) [![Umbraco Marketplace](https://img.shields.io/badge/umbraco-marketplace-%233544B1)](https://marketplace.umbraco.com/package/limbo.umbraco.recyclebin)

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
