using Domain.IRepository;
using Domain.Model;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Repository.EntityFrameCore.DBContext
{
    /// <summary>
    /// 日志仓储类
    /// </summary>
    public class JournalRepository : IJournalRepository
    {
        #region 字段定义
        private EFDBContext context;
        private IAccountService accountService;
        #endregion

        #region 构造函数
        public JournalRepository()
        {
        }
        public JournalRepository(EFDBContext context, IAccountService accountService)
        {
            this.context = context;//new EFDBContext();
            this.accountService = accountService;
        }
        #endregion

        public bool Delete(JournalModel obj)
        {
            bool isSuccess = false;
            JournalModel model = this.context.JournalModels.Find(obj.JournalID);
            if (model != null)
            {
                this.context.JournalModels.Remove(model);
                this.context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public IEnumerable<JournalModel> GetAll()
        {
            return this.context.JournalModels.
                Where(obj=>obj.User==accountService.GetCurrentUser().Result).
                Select(obj=>obj);
        }

        public async Task<IEnumerable<JournalModel>> GetAllAsync()
        {
            Task<IEnumerable<JournalModel>> task = new Task<IEnumerable<JournalModel>>
                (() => { return this.context.JournalModels; });
            return await task; ;
        }

        public JournalModel GetEntity(string id)
        {
            return this.context.JournalModels.Find(id);
        }

        public long SaveEntity(JournalModel obj)
        {
            obj.UserId = this.accountService.GetCurrentUser().Result.Id;
            this.context.JournalModels.Add(obj);
            return (long)this.context.SaveChanges();

        }

        public bool UpdateEntity(JournalModel obj)
        {
            bool isSuccess = false;
            JournalModel model = this.context.JournalModels.Find(obj.JournalID);
            if (model != null)
            {
                model.JournalID = obj.JournalID;
                model.Title = obj.Title;
                model.Content = obj.Content;
                model.JournalDate = obj.JournalDate;
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
