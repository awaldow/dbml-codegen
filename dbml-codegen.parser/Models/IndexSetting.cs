namespace dbmlcodegen.parser.Models
{
    public class IndexSetting
    {
        public IndexSettingType SettingType { get; set; }
        public IndexType Type { get; set; }
        public string Name { get; set; }
    }

    public enum IndexSettingType
    {
        Name,
        Unique,
        PrimaryKey,
        Type
    }

    public enum IndexType
    {
        Btree,
        Gin,
        Gist,
        Hash
    }
}