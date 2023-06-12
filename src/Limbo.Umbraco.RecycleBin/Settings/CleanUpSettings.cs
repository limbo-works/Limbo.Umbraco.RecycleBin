namespace Limbo.Umbraco.RecycleBin.Settings {
    public class CleanUpSettings {

        public bool Enabled { get; internal set; } = false;

        public int DeleteAfterDays { get; internal set; } = 30;

    }
}
