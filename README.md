# Limbo Recycle Bin

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md)
[![NuGet](https://img.shields.io/nuget/vpre/Limbo.Umbraco.RecycleBin.svg)](https://www.nuget.org/packages/Limbo.Umbraco.RecycleBin)
[![NuGet](https://img.shields.io/nuget/dt/Limbo.Umbraco.RecycleBin.svg)](https://www.nuget.org/packages/Limbo.Umbraco.RecycleBin)
[![Umbraco Marketplace](https://img.shields.io/badge/umbraco-marketplace-%233544B1)](https://marketplace.umbraco.com/package/limbo.umbraco.recyclebin)

**Limbo Recycle Bin** helps you handle your Umbraco recycle bin.

- It automatically deletes items in the recycle bin that were deleted x days ago. Both content og media.
- It physical moves trashed media items so that they are not available to download.


## Installation

The Umbraco 13 version of this package is only available via [**NuGet**](https://www.nuget.org/packages/Limbo.Umbraco.RecycleBin/13.0.0). To install the package, you can use either .NET CLI:

```
dotnet add package Limbo.Umbraco.RecycleBin --version 13.0.0
```

or the older NuGet Package Manager:

```
Install-Package Limbo.Umbraco.RecycleBin -Version 13.0.0
```

**Umbraco 10-12**  
For the Umbraco 10-12 version of this package, see the [**v1/main**](https://github.com/limbo-works/Limbo.Umbraco.RecycleBin/tree/v1/main) branch instead.

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
