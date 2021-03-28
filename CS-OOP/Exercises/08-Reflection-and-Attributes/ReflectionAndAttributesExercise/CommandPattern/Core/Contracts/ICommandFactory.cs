using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    internal interface ICommandFactory
    {
        ICommand CreateCommand(string commandType);
    }
}