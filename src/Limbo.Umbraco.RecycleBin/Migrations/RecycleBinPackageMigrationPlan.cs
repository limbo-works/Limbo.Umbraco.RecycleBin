using Umbraco.Cms.Core.Packaging;
using Umbraco.Cms.Infrastructure.Migrations;

namespace Limbo.Umbraco.RecycleBin.Migrations {

    public class RecycleBinPackageMigrationPlan : PackageMigrationPlan {

        public RecycleBinPackageMigrationPlan() : base("Limbo.Umbraco.RecycleBin") { }

        protected override void DefinePlan() {
            To<NoopMigration>(new Guid("8F3A1C42-5B6E-4A1D-9C2E-0F7B4D6E8A12"));
        }

    }

}
