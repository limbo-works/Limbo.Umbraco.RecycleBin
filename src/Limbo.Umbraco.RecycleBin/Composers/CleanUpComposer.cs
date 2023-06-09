using Limbo.Umbraco.RecycleBin.Scheduling;
using Limbo.Umbraco.RecycleBin.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Limbo.Umbraco.RecycleBin.Composers {
    public class CleanUpComposer : IComposer {
        public void Compose(IUmbracoBuilder builder) {
            builder.Services.AddSingleton<CleanUpService>();
            builder.Services.AddHostedService<CleanUpTask>();
        }
    }
}
