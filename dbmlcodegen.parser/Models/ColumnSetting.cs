namespace dbmlcodegen.parser.Models
{
    public class ColumnSetting
    {
        public ColumnSettingType Type { get; set; }
        public string SettingValue { get; set; }

        public ColumnSetting(string settingType, string settingValue)
        {
            switch (settingType)
            {
                case "primary key":
                case "pk": Type = ColumnSettingType.PrimaryKey; break;
                case "not null": Type = ColumnSettingType.NotNull; break;
                case "null": Type = ColumnSettingType.Null; break;
                case "unique": Type = ColumnSettingType.Unique; break;
                case "increment": Type = ColumnSettingType.Increment; break;
                case "default": Type = ColumnSettingType.Default; break;
                case "note": Type = ColumnSettingType.Note; break;
                default: break;
            }
            SettingValue = settingValue;
        }
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