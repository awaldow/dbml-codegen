namespace dbmlcodegen.parser.Models
{
    public class Table
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Note { get; set; }
        public List<Column> Columns { get; set; }
        public List<Index> Indexes {get;set;}

        public Table()
        {
            this.Columns = new List<Column>();
            this.Indexes = new List<Index>();
        }
    }
}