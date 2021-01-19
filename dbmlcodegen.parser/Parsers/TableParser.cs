using dbmlcodegen.parser.Models;

namespace dbmlcodegen.parser.Parsers
{
    public class TableParser: ITokenParser<Table>
    {
        private string table { get; set; }

        public TableParser(string tableString)
        {
            table = tableString;
        }

        public Table Generate<Table>()
        {
            var ret = new Table();
            return ret;
        }
    }
}