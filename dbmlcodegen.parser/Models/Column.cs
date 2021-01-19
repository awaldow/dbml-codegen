using System.Collections.Generic;

namespace dbmlcodegen.parser.Models
{
    public class Column
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Note {get;set;}
        public List<ColumnSetting> ColumnSettings {get;set;}

        public Column() {
            this.ColumnSettings = new List<ColumnSetting>();
        }
    }
}