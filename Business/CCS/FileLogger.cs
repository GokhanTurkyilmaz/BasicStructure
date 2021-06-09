using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS
{
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Dosyaya Log yapildi");
        }
    }
    public class DataBaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Veri Tabanina Log yapildi");
        }
    }
}
