using Domain.IRepositories;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
  public interface IJournalRepository: IRepository<JournalModel>
    {
        IEnumerable<JournalModel> GetAll();

        Task<IEnumerable<JournalModel>> GetAllAsync();
    }
}
