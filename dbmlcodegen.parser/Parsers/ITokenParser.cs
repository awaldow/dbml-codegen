namespace dbmlcodegen.parser.Parsers
{
    public interface ITokenParser<T>
    {
        public T Generate();
    }
}