using MusicMarketETicaret.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicMarketETicaret.DataAccess.IMainRepository
{
   public interface ICategoryRepository : IRepository<Category> 
    {
        void Update(Category category);
        
    }
}
