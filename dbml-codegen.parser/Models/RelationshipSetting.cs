namespace dbmlcodegen.parser.Models
{
    public class RelationshipSetting
    {
        public ActionType Action { get; set; }
        public RelationshipSettingType SettingType { get; set; }
    }

    public enum ActionType
    {
        Delete,
        Update
    }

    public enum RelationshipSettingType
    {
        Cascade,
        Restrict,
        SetNull,
        SetDefaul,
        NoAction
    }
}