using System.IO;
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

        public Table Generate()
        {
            var ret = new Table();
            var line = "";
            using (StringReader reader = new StringReader(table))
            {
                do
                {
                    line = reader.ReadLine();
                    if (line.IndexOf("{") != -1) // First line, might have table name and alias, also note
                    {
                        var split = line.Split(" ");
                        if (split[1] != "{")
                        {
                            ret.Name = split[1];
                        }
                        if (split.Length == 5)
                        {
                            ret.Alias = split[3];
                        }
                    }
                    else if (line.IndexOf("{") == -1 && line.IndexOf("}") != 0) // Intermediate row
                    {
                        var split = line.Split(":");
                        var field = split[0].Trim();
                        var value = split[1].Trim().Replace("\'", string.Empty);
                    }
                }
                while (line.IndexOf("}") == -1 && line != null);
            }

            return ret;
        }
    }
}