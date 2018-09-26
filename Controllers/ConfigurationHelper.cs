using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Controllers
{
    public class ConfigurationHelper
    {
        /// <summary>取得 appsettings.json 設定檔</summary>
        /// <returns></returns>
        public static IConfigurationRoot AppSettings() {
           return new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .AddJsonFile(path: $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
            .Build();
        }
        /// <summary>取得資料庫連線字串</summary>
        /// <param name="connectionStringKey">資料庫連線字串的鍵值</param>
        /// <returns></returns>
        public static string GetConnectionString(string connectionStringKey)
        {
            return AppSettings().GetConnectionString(connectionStringKey);
        }
    }
}
