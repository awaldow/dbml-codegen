using System.IO;
using dbmlcodegen.parser.Models;

namespace dbmlcodegen.parser.Parsers
{
    public class TableParser : ITokenParser<Table>
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
                        var split = line.Split(" ");
                        if (split[0] == "indexes")
                        {

                        }
                        else if (split[0] == "Note:")
                        {
                            ret.Note = split[1].Replace("\'", string.Empty).Trim();
                        }
                        else
                        {
                            var columnName = split[0].Trim();
                            var columnType = split[1].Trim().Replace("\'", string.Empty);
                            var newColumn = new Column
                            {
                                Name = columnName,
                                Type = columnType
                            };

                            if (split.Length > 2 && split[2].IndexOf("[") != -1)
                            {
                                if (split[2].IndexOf(",") != -1) // settings list
                                {
                                    var settingsSplit = split[2].Replace("[", "").Replace("]", "").Split(",");
                                    foreach (var setting in settingsSplit)
                                    {
                                        var settingValue = "";
                                        if (setting.IndexOf(":") != -1) // default or note, so we need to extract the value
                                        {
                                            settingValue = setting.Split(":")[1].Replace("'", "").Trim();
                                        }
                                        var columnSetting = new ColumnSetting(setting, settingValue);
                                        newColumn.ColumnSettings.Add(columnSetting);
                                    }
                                }
                                else if (split[2].IndexOf("ref") != -1) // inline ref
                                {

                                }
                            }
                        }
                    }
                }
                while (line.IndexOf("}") == -1 && line != null);
            }

            return ret;
        }
    }
}