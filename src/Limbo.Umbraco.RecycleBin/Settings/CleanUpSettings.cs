namespace Limbo.Umbraco.RecycleBin.Settings {
    public class CleanUpSettings {

        public bool Enabled { get; set; } = false;

        public int DeleteAfterDays { get; set; } = 30;

    }
}
