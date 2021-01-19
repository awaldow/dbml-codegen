using System;
using CommandLine;
using dbmlcodegen.parser;

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
                       DBMLParser p = new DBMLParser(o.InputFile);
                       p.Parse();
                   });
        }
    }
}
