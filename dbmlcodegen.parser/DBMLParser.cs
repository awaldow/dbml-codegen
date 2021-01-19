using System;
using System.IO;
using System.Text;
using dbmlcodegen.parser.Models;
using dbmlcodegen.parser.Parsers;

namespace dbmlcodegen.parser
{
    public class DBMLParser
    {
        private string inputDocumentPath { get; set; }
        private StreamReader reader { get; set; }
        public Project Project { get; set; }

        public DBMLParser(string input)
        {
            inputDocumentPath = input;
            reader = new StreamReader(input);
            Project = new Project();
        }

        public void Parse()
        {
            using(reader)
            {
                var line = "";
                do 
                {
                    // (string output, nextStart) = getNextBlock(input, nextStart);
                    // Console.WriteLine(output);
                    line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        var tokens = line.Split(" ");
                        var tokenType = determineTokenType(line);
                        var wholeToken = getWholeBlock(reader, line);
                        switch (tokenType)
                        {
                            case TokenType.Project:
                                Project = new ProjectParser(wholeToken).Generate();
                                break;
                            case TokenType.Table:
                                var table = new TableParser(wholeToken);
                                Project.Tables.Add(table.Generate());
                                break;
                            default:
                                Console.WriteLine($"No parser for token {tokenType} yet");
                                break;
                        }
                    }
                }
                while (line != null);
            }
        }

        private string getWholeBlock(StreamReader reader, string line)
        {
            var ret = new StringBuilder();
            ret = ret.AppendLine(line);
            if (line.IndexOf("}") != -1) // If it's a one line definition (i.e. empty)
            {
                return ret.ToString();
            }
            else
            {
                bool keepChecking = true;
                do
                {
                    var nextLine = reader.ReadLine();
                    ret.AppendLine(nextLine);
                    keepChecking = nextLine.IndexOf("}") == -1;
                }
                while (keepChecking);
                return ret.ToString();
            }
        }

        private TokenType determineTokenType(string line)
        {
            var split = line.Split(" ");
            switch (split[0])
            {
                case "Project": return TokenType.Project;
                case "Table": return TokenType.Table;
                case "Ref": return TokenType.Ref;
                case "Enum": return TokenType.Enum;
                default: Console.WriteLine($"No defined token type for {split[0]}"); return TokenType.Unknown;
            }
        }

        private enum TokenType
        {
            Project,
            Table,
            Ref,
            Enum,
            Unknown
        }
    }
}