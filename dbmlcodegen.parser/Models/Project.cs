using System.Collections.Generic;
using dbmlcodegen.parser.Attributes;

namespace dbmlcodegen.parser.Models {
    public class Project {
        [DbmlFieldName("database_type")]
        public string DatabaseType { get; set; }
        [DbmlFieldName("Note")]
        public string Note { get; set; }
        public string Name { get; set; }

        public List<Table> Tables {get;set;}

        public Project() {
            this.Tables = new List<Table>();
        }
    }
}