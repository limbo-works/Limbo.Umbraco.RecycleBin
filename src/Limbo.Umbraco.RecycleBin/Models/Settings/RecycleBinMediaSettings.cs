namespace Limbo.Umbraco.RecycleBin.Models.Settings;

public class RecycleBinMediaSettings {

    public bool Enabled { get; set; } = false;

    public int DeleteAfterDays { get; set; } = 30;

}