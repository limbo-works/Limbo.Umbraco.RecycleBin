using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;

namespace Limbo.Umbraco.RecycleBin.Manifests;

public class RecycleBinPackageManifestReader : IPackageManifestReader {

    public async Task<IEnumerable<PackageManifest>> ReadPackageManifestsAsync() {

        List<PackageManifest> manifests = [
            new PackageManifest {
                Id = RecycleBinPackage.Alias,
                Name = RecycleBinPackage.Name,
                AllowTelemetry = true,
                Version = RecycleBinPackage.InformationalVersion,
                Extensions = []
            }
        ];

        return await Task.FromResult(manifests);

    }

}