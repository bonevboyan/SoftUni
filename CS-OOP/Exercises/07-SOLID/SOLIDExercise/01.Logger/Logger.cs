using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger
{
    class Logger : ILogger
    {
        private IAppender consoleAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public void Error(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public void Info(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
