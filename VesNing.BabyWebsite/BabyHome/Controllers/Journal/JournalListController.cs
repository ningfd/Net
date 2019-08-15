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
    public class JournalListController:Controller
    {
        #region 字段定义
        private IJournalRepository journalRepository;
        #endregion

        #region 构造函数
        public JournalListController(IJournalRepository journalRepository)
        {
            this.journalRepository = journalRepository;
        }
        #endregion
        
        public IEnumerable<JournalModel> ShowJournalList()
        {
            IEnumerable<JournalModel> list = this.journalRepository.GetAll();
            return list;
        }
        [HttpGet]
        [Authorize]
        public object[] ShowImagePaginated(int pageIndex, int pageSize)
        {
            IEnumerable<JournalModel> list = this.journalRepository.GetAll();
            int pageCont = list.Count();
            IEnumerable<JournalModel> taskList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new object[] { pageCont, taskList };
        }
    }
}