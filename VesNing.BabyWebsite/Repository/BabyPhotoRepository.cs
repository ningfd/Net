using Domain.IRepository;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Infrastructure.Identity;

namespace Repository.EntityFrameCore
{
  public  class BabyPhotoRepository : IBabyPhotoRepository
    {
        #region 字段定义
        private EFDBContext context;
        private IAccountService accountService;
        #endregion

        #region 构造函数
        public BabyPhotoRepository(EFDBContext context,IAccountService accountService)
        {
            this.context = context;
            this.accountService = accountService;
        }
        #endregion

        public bool Delete(BabyPhotoModel obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BabyPhotoModel> GetAll()
        {
            return this.context.BabyPhotoModels.
                Where(obj=>obj.User== accountService.GetCurrentUser().Result).
                Select(obj=>obj);
            
        }

        public BabyPhotoModel GetEntity(string id)
        {
            throw new NotImplementedException();
        }

        public long SaveEntity(BabyPhotoModel obj)
        {
            obj.UserId = this.accountService.GetCurrentUser().Result.Id;
            this.context.BabyPhotoModels.Add(obj);
            return this.context.SaveChanges();
        }

        public bool UpdateEntity(BabyPhotoModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
