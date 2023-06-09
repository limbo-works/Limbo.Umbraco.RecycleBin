using Umbraco.Cms.Core.Manifest;

namespace Limbo.Umbraco.RecycleBin.Manifests {
    public class RecycleBinPackageManifestFilter : IManifestFilter {

        public void Filter(List<PackageManifest> manifests) {
            manifests.Add(new PackageManifest {
                AllowPackageTelemetry = true,
                PackageName = RecycleBinPackage.Name,
                Version = RecycleBinPackage.InformationalVersion
            });
        }

    }
}
