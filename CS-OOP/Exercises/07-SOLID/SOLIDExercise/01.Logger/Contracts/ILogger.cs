namespace _01.Logger
{
    internal interface ILogger
    {
        void Error(string datetime, string parsingMethod);

        void Info(string datetime, string message);

        void Fatal(string datetime, string message);

        void Critical(string datetime, string message);
    }
}