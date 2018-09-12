namespace StringParserAssignment.Services
{
    public interface IParserService
    {
        string Parse(string input, string parserType);

        string[] GetAllParsers();
    }
}
