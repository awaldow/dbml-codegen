namespace dbmlcodegen.parser.Models
{
    public class Index
    {
        public string Fields { get; set; }
        public string Note { get; set; }
        public List<IndexSetting> IndexSettings { get; set; }
        public Index()
        {
            IndexSettings = new List<IndexSetting>();
        }
    }
}