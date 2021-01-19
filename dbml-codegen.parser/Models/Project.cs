namespace dbmlcodegen.parser.Models {
    public class Project {
        public string DatabaseType { get; set; }    
        public string Note { get; set; }

        public List<Table> Tables {get;set;}

        public Project() {
            this.Tables = new List<Table>();
        }

        public static Project fromString(string projectString) {
            
        }
    }
}