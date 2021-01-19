namespace dbmlcodegen.parser.Models
{
    public class Ref
    {
        public Table PrimaryTable { get; set; }
        public Table SecondaryTable { get; set; }
        public Relationship Relationship { get; set; }
        public List<RelationshipSetting> RelationshipSettings { get; set; }
        public Ref()
        {
            RelationshipSettings = new List<RelationshipSetting>();
        }
    }
}