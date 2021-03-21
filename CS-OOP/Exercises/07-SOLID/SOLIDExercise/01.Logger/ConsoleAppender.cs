namespace _01.Logger
{
    internal class ConsoleAppender : IAppender
    {
        private ILayout simpleLayout;

        public ConsoleAppender(ILayout simpleLayout)
        {
            this.simpleLayout = simpleLayout;
        }
    }
}