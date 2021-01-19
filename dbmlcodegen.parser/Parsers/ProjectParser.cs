using dbmlcodegen.parser.Models;

namespace dbmlcodegen.parser.Parsers
{
    public class ProjectParser : ITokenParser<Project>
    {
        private string project { get; set; }

        public ProjectParser(string projectString)
        {
            project = projectString;
        }

        public Project Generate<Project>()
        {
            var ret = new Project();
            return ret;
        }
    }
}