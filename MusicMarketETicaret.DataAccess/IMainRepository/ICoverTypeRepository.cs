using MusicMarketETicaret.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicMarketETicaret.DataAccess.IMainRepository
{
   public interface ICoverTypeRepository: IRepository<CoverType>
    {
        void Update(CoverType coverType);

    }
}
