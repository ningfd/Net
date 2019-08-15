using System;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.EntityFrameCore;
using Repository.EntityFrameCore.DBContext;

namespace Test
{
    [TestClass]
    public class JournalTest
    {
        [TestMethod]
        public void EFConnection()
        {
            //EFDBContext context = new EFDBContext();
            //bool success=context.Database.CanConnect();
            //Assert.AreEqual(true,success);
        }
        [TestMethod]
        public void InsertJournal()
        {
            JournalModel model = new JournalModel()
            {
                JournalID = Guid.NewGuid().ToString(),
                Title = "保存测试",
                Content = "Journal一条记录将保存到数据库",
                JournalDate = DateTime.Now
            };
            JournalRepository repository = new JournalRepository();
            long result = repository.SaveEntity(model);
            Assert.AreEqual(1,result);
        }
    }
}
