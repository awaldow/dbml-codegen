using System;

namespace dbmlcodegen.generator
{
    class Program
    {
        static void Main(string[] args)
        {
             Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       Console.WriteLine($"Parsing {o.InputFile}");
                       using(Parser p = new Parser(File.ReadAllText(o.InputFile))) {
                           p.Parse();
                       }
                   });
        }
    }
}
