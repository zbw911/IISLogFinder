using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogComm;

namespace ConsoleUseLog
{
    class Program
    {
        static void Main(string[] args)
        {
            LogParseWapper cls = new LogParseWapper();

            cls.ParseW3CLog(@"d:\Users\Administrator\Documents\IISExpress\Logs\WebApplication1(11)", "503");
        }
    }
}
