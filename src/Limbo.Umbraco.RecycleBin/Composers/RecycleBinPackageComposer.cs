using Limbo.Umbraco.RecycleBin.Manifests;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Limbo.Umbraco.RecycleBin.Composers {
    public class RecycleBinPackageComposer : IComposer {

        public void Compose(IUmbracoBuilder builder) {
            builder.ManifestFilters().Append<RecycleBinPackageManifestFilter>();
        }

    }
}
