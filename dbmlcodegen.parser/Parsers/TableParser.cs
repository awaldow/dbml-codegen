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
                    line = reader.ReadLine().Trim();
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
                        var split = line.Split("[");
                        var column = split[0].Split(" ");
                        var columnSettings = split.Length > 1 ? split[1] : "";
                        if (column[0] == "indexes")
                        {

                        }
                        else if (column[0] == "Note:")
                        {
                            ret.Note = column[1].Replace("\'", string.Empty).Trim();
                        }
                        else if(column.Length > 1)
                        {
                            var columnName = column[0].Trim();
                            var columnType = column[1].Trim().Replace("\'", string.Empty);
                            var newColumn = new Column
                            {
                                Name = columnName,
                                Type = columnType
                            };

                            if (columnSettings.Length > 0)
                            {
                                if (columnSettings.IndexOf("ref") != -1) // inline ref
                                {
                                    
                                }
                                else // settings list
                                {
                                    var settingsSplit = columnSettings.Replace("[", "").Replace("]", "").Split(",");
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