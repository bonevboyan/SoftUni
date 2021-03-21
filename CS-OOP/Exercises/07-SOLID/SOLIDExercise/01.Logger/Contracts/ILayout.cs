namespace _01.Logger
{
    interface ILayout
    {
        string FormatReport(string datetime, string reportLevel, string message);
    }
}