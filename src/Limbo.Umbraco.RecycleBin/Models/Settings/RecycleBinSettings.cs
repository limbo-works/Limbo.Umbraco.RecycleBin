namespace Limbo.Umbraco.RecycleBin.Models.Settings;

public class RecycleBinSettings {

    public RecycleBinContentSettings Content { get; set; } = new();

    public RecycleBinMediaSettings Media { get; set; } = new();

}