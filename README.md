# Limbo Recycle Bin

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/limbo-works/Limbo.Umbraco.RecycleBin/blob/v17/main/LICENSE.md)
[![NuGet](https://img.shields.io/nuget/vpre/Limbo.Umbraco.RecycleBin.svg)](https://www.nuget.org/packages/Limbo.Umbraco.RecycleBin)
[![NuGet](https://img.shields.io/nuget/dt/Limbo.Umbraco.RecycleBin.svg)](https://www.nuget.org/packages/Limbo.Umbraco.RecycleBin)
[![Umbraco Marketplace](https://img.shields.io/badge/umbraco-marketplace-%233544B1)](https://marketplace.umbraco.com/package/limbo.umbraco.recyclebin)

**Limbo Recycle Bin** helps you handle your Umbraco recycle bin.

- It automatically deletes items in the recycle bin that were deleted x days ago. Both content and media.
- It physical moves trashed media items so that they are not available to download.

<table>
  <tr>
    <td><strong>License:</strong></td>
    <td><a href="https://github.com/limbo-works/Limbo.Umbraco.RecycleBin/blob/v17/main/LICENSE.md"><strong>MIT License</strong></a></td>
  </tr>
  <tr>
    <td><strong>Umbraco:</strong></td>
    <td>
      Umbraco 17
    </td>
  </tr>
  <tr>
    <td><strong>Target Framework:</strong></td>
    <td>
      .NET 10
    </td>
  </tr>
</table>








<br /><br />

## Installation

### Umbraco 17

The Umbraco 17 version of this package is only available via [**NuGet**](https://www.nuget.org/packages/Limbo.Umbraco.RecycleBin). To install the package, you can use either .NET CLI:

```
dotnet add package Limbo.Umbraco.RecycleBin --version 17.0.0-alpha001
```

or the NuGet Package Manager:

```
Install-Package Limbo.Umbraco.RecycleBin -Version 17.0.0-alpha001
```

### Other versions of Umbraco

- [**`v13/main`**](https://github.com/limbo-works/Limbo.Umbraco.RecycleBin/tree/v13/main) Umbraco 13
- ~~[**`v1/main`**](https://github.com/limbo-works/Limbo.Umbraco.RecycleBin/tree/v1/main) Umbraco 10, 11 and 12~~ <sub title="Umbraco 10, 11 and 12 have reached end-of-life"><sup>(EOL)</sup></sub>




<br /><br />

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
