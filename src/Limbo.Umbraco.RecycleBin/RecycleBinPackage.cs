using System.Diagnostics;
using Umbraco.Cms.Core.Semver;

namespace Limbo.Umbraco.RecycleBin {
    public class RecycleBinPackage {

        /// <summary>
        /// Gets the alias of the package.
        /// </summary>
        public const string Alias = "Limbo.Umbraco.RecycleBin";

        /// <summary>
        /// Gets the friendly name of the package.
        /// </summary>
        public const string Name = "Limbo Recycle Bin";

        /// <summary>
        /// Gets the version of the package.
        /// </summary>
        public static readonly Version Version = typeof(RecycleBinPackage).Assembly.GetName().Version!;

        /// <summary>
        /// Gets the informational version of the package.
        /// </summary>
        public static readonly string InformationalVersion = FileVersionInfo.GetVersionInfo(typeof(RecycleBinPackage).Assembly.Location).ProductVersion!.Split('+')[0];

        /// <summary>
        /// Gets the semantic version of the package.
        /// </summary>
        public static readonly SemVersion SemVersion = InformationalVersion;

        /// <summary>
        /// Gets the URL of the GitHub repository for this package.
        /// </summary>
        public const string GitHubUrl = "https://github.com/limbo-works/Limbo.Umbraco.RecycleBin/";

        /// <summary>
        /// Gets the URL of the issue tracker for this package.
        /// </summary>
        public const string IssuesUrl = "https://github.com/limbo-works/Limbo.Umbraco.RecycleBin/issues";

        /// <summary>
        /// Gets the website URL of the package.
        /// </summary>
        //public const string WebsiteUrl = "https://packages.skybrud.dk/skybrud.umbraco.griddata/v5/";

        /// <summary>
        /// Gets the URL of the documentation for this package.
        /// </summary>
        //public const string DocumentationUrl = "https://packages.skybrud.dk/skybrud.umbraco.griddata/v5/docs/";

    }
}
