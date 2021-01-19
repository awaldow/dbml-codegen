namespace dbmlcodegen.generator
{
    public class Options
    {
        [Option('f', "file", Required = true, HelpText = "Absolute or relative path to dbml input.")]
        public string InputFile { get; set; }
    }
}