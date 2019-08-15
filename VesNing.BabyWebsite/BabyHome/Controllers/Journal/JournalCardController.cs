using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.IRepository;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BabyHome.Controllers
{
    [Route("api/[controller]")]
    public class JournalCardController:Controller
    {
        #region 字段定义
        private IJournalRepository journalRepository;
        #endregion

        #region 构造函数
        public JournalCardController(IJournalRepository journalRepository)
        {
            this.journalRepository = journalRepository;
        }
        #endregion

        #region 根据ID获取数据
        [HttpGet]
        [Authorize]
        public JournalModel GetJournalByID(string id)
        {
           return journalRepository.GetEntity(id);
        }
        #endregion

        #region 保存数据
        [HttpPost]
        [Authorize]
        public bool SaveEntity([FromBody] JournalModel obj)
        {
            JournalModel entity = new JournalModel()
            {
                Title = obj.Title,
                Content = obj.Content,
                JournalID = Guid.NewGuid().ToString(),
                JournalDate=DateTime.Now
                
            };
            return this.journalRepository.SaveEntity(entity) > 0 ? true:false ;
        }
        #endregion

    }
}