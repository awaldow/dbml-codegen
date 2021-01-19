namespace dbmlcodegen.parser.Models
{
    public class Parser
    {
        private string inputDocument { get; set; }
        public Project Project { get; set; }

        public Parser(string input)
        {
            inputDocument = input;
            Project = new Project();
        }

        public void Parse()
        {
            int nextStart = 0;
            do
            {
                (string output, nextStart) = getNextBlock(input, nextStart);
                Console.WriteLine(output);
            }
            while (nextStart != -1);
        }

        private (string, int) getNextBlock(string input, int startIndex)
        {
            int endLocation = input.IndexOf('}', startIndex, System.StringComparison.Ordinal); // Get the end bracket
            string output = input.Substring(startIndex, endLocation - startIndex);
            return (output, endLocation);
        }
    }
}