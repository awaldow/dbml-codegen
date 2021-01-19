namespace dbmlcodegen.parser.Models
{
    public class ColumnSetting
    {
        public ColumnSettingType Type { get; set; }
        public string SettingValue { get; set; }
    }

    public enum ColumnSettingType
    {
        Note,
        PrimaryKey,
        Null,
        NotNull,
        Unique,
        Default,
        Increment
    }
}