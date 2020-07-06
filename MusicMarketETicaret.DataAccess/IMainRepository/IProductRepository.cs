using MusicMarketETicaret.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicMarketETicaret.DataAccess.IMainRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);

    }
}
