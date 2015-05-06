using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSUtil;

namespace LogComm
{
    public class LogParseWapper
    {
        public string ParseW3CLog(string path, string code)
        {

            return CommParseW3CLog(path + @"\\*.log", "sc-status = '" + code + "'");


        }

        public string ParseW3CLog(string[] filenames, string code)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var filename in filenames)
            {
                var txt = CommParseW3CLog(filename, " sc-status = '" + code + "'");

                sb.Append(txt);
            }

            return sb.ToString();
        }



        private static string CommParseW3CLog(string path, string where)
        {
            // prepare LogParser Recordset & Record objects
            ILogRecordset rsLP = null;
            ILogRecord rowLP = null;

            LogQueryClassClass logParser = null;
            COMW3CInputContextClassClass w3Clog = null;

            logParser = new LogQueryClassClass();
            w3Clog = new COMW3CInputContextClassClass();

            try
            {

                var strSql = @"SELECT * from " + path + " WHERE " + @where + " ";

                // run the query against W3C log
                rsLP = logParser.Execute(strSql, w3Clog);


                var count = rsLP.getColumnCount();
                var allname = "";
                for (int i = 0; i < count; i++)
                {
                    var mame = rsLP.getColumnName(i);

                    allname += "-" + mame;
                }

                Console.WriteLine(allname);


                StringBuilder sb = new StringBuilder();


                while (!rsLP.atEnd())
                {
                    rowLP = rsLP.getRecord();


                    for (int i = 0; i < count; i++)
                    {
                        var v = rowLP.getValue(i);
                        Console.Write(v + "\t");

                        sb.Append(v + "\t");
                    }

                    Console.WriteLine();
                    sb.Append(Environment.NewLine);
                    rsLP.moveNext();
                }

                return sb.ToString();

            }
            catch
            {
                throw;
            }
        }
    }
}
