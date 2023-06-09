namespace Limbo.Umbraco.RecycleBin.Settings {
    public class CleanUpSetting {

        public bool Enabled { get; internal set; } = false;

        public int DeleteAfterDays { get; internal set; } = 1;

    }
}
