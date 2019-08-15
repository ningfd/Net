using Domain.IRepositories;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
   public interface IBabyPhotoRepository: IRepository<BabyPhotoModel>
    {
        IEnumerable<BabyPhotoModel> GetAll();
    }
}
