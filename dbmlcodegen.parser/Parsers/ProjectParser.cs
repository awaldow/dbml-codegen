using System;
using System.IO;
using System.Linq;
using System.Reflection;
using dbmlcodegen.parser.Attributes;
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

        public Project Generate()
        {
            var ret = new Project();
            var props = from p in ret.GetType().GetProperties()
                        let attr = p.GetCustomAttributes<DbmlFieldNameAttribute>()
                        where attr.Count() > 0
                        select new { Property = p, Attribute = attr.First() as DbmlFieldNameAttribute };
            var line = "";
            using (StringReader reader = new StringReader(project))
            {
                do
                {
                    line = reader.ReadLine();
                    if (line.IndexOf("{") != -1) // First line, might have project name
                    {
                        var split = line.Split(" ");
                        if (split[1] != "{")
                        {
                            ret.Name = split[1];
                        }
                    }
                    else if (line.IndexOf("{") == -1 && line.IndexOf("}") != 0) // Intermediate row
                    {
                        var split = line.Split(":");
                        var field = split[0].Trim();
                        var value = split[1].Trim().Replace("\'", string.Empty);
                        props.SingleOrDefault(p => p.Attribute.FieldName == field).Property.SetValue(ret, value);
                    }
                }
                while (line.IndexOf("}") == -1 && line != null);
            }

            return ret;
        }
    }
}