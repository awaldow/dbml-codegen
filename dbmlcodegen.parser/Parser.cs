namespace dbmlcodegen.parser.Models
{
    public class Parser
    {
        private string inputDocumentPath { get; set; }
        private StreamReader reader { get; set; }
        public Project Project { get; set; }

        public Parser(string input)
        {
            inputDocumentPath = input;
            reader = new StreamReader(input);
            Project = new Project();
        }

        public void Parse()
        {
            using(reader)
            {
                do 
                {
                    // (string output, nextStart) = getNextBlock(input, nextStart);
                    // Console.WriteLine(output);
                    var line = strReader.ReadLine();
                    var tokens = line.Split(" ");
                    var tokenType = determineTokenType(line);
                    var wholeToken = getWholeBlock(reader, line);
                    switch (tokenType)
                    {
                        case TokenType.Project:
                            Project = new ProjectParser(wholeToken).GenerateProject();
                            break;
                        case TokenType.Table:
                            var table = new TableParser(wholeToken);
                            Project.Tables.Add(table.GenerateTable());
                            break;
                        default:
                            Console.WriteLine($"No parser for token {tokenType} yet");
                    }
                }
                while (nextStart != -1);
            }
        }

        private string getWholeBlock(StreamReader reader, string line)
        {
            var ret = new StringBuilder(line);
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
                default: Console.WriteLine($"No defined token type for {split[0]}"); return null;
            }
        }

        private enum TokenType
        {
            Project,
            Table,
            Ref,
            Enum
        }
    }
}