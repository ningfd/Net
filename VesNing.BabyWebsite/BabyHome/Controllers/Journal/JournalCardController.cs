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
        #region �ֶζ���
        private IJournalRepository journalRepository;
        #endregion

        #region ���캯��
        public JournalCardController(IJournalRepository journalRepository)
        {
            this.journalRepository = journalRepository;
        }
        #endregion

        #region ����ID��ȡ����
        [HttpGet]
        [Authorize]
        public JournalModel GetJournalByID(string id)
        {
           return journalRepository.GetEntity(id);
        }
        #endregion

        #region ��������
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