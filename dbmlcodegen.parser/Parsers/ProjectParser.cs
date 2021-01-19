using dbmlcodegen.parser.Models;

namespace dbmlcodegen.parser.Parsers
{
    public class ProjectParser
    {
        private string project { get; set; }

        public ProjectParser(string projectString)
        {
            project = projectString;
        }

        public Project GenerateProject()
        {
            var ret = new Project();
            return ret;
        }
    }
}