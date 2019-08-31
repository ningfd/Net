using System;
using VesNing.EdutureCore.Util;

namespace VesNing.EdutureCore.Test
{
    class ConfigFileTest
    {
        static void Main(string[] args)
        {
            JsonConifgUtil util =JsonConifgUtil.Currnet;
           string result=util.AddFile("system","appsettings.json").
                ReadConfig("system").
                GetValue("ConnectionSql");
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
