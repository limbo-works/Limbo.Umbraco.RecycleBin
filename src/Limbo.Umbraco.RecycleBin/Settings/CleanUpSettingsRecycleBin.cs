namespace Limbo.Umbraco.RecycleBin.Settings;

public class CleanUpSettingsRecycleBin {

    public CleanUpSettings Content { get; set; } = new();

    public CleanUpSettings Media { get; set; } = new();

}