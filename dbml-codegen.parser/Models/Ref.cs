namespace dbmlcodegen.parser.Models
{
    public class Ref
    {
        public Table PrimaryTable { get; set; }
        public Table SecondaryTable { get; set; }
        public Relationship Relationship { get; set; }
    }
}