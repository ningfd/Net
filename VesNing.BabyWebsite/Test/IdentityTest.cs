
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class IdentityTest
    {
        [TestMethod]
        public void InitDatabase()
        {
            AppIdentityContext context = new AppIdentityContext();
            string sql = context.Database.GenerateCreateScript();
            FileStream fs = File.Create(@"e:/identity_Mysql.sql");
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(sql);

            sw.Close();
            fs.Close();
            //bool mark = context.Database.EnsureCreated();
            Assert.AreEqual(sql.Length > 0, true);
        }
    }
}
