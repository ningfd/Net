using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Infrastructure.Util
{
    public class ConfigHelper
    {
        private static readonly IConfiguration Instance;
        static ConfigHelper()
        {
            Instance = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
                AddEnvironmentVariables().
                Build();
        }
        public static Action<DbContextOptionsBuilder> GetDbConnection()
        {
            Action<DbContextOptionsBuilder> action = null;
            string type = Instance.GetSection("ConnectionType").Value;
            string section = "";
            switch (type)
            {
                case "sqlserver":
                    section = "SqlServerConnection";
                    action = (options) =>
                    {
                        options.UseSqlServer(Instance.GetConnectionString(section));
                    };
                    break;
                case "mysql":
                    section = "MySqlConnection";
                    action = (options) =>
                    {
                        options.UseMySQL(Instance.GetConnectionString(section));
                    };
                    break;
                default:
                    break;
            }

            return action;
        }
    }
}
