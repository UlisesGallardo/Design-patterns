using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Log
    {
        private Binnacle logger;
        public Log()
        {
            logger = new TxtFile();
        }
        public void execute(string text)
        {
            logger.Write(text);
        }

        public void setLogger(Binnacle strategy)
        {
            logger = strategy;
        }
    }
}
