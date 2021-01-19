using dbmlcodegen.parser.Models;

namespace dbmlcodegen.parser.Parsers
{
    public class TableParser
    {
        private string table { get; set; }

        public TableParser(string tableString)
        {
            table = tableString;
        }

        public Table GenerateTable()
        {
            var ret = new Table();
            return ret;
        }
    }
}