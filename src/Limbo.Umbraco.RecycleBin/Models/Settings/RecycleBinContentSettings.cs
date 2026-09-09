namespace Limbo.Umbraco.RecycleBin.Models.Settings;

public class RecycleBinContentSettings {

    public bool Enabled { get; set; } = false;

    public int DeleteAfterDays { get; set; } = 30;

}