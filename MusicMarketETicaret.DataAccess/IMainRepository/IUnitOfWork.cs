using System;
using System.Collections.Generic;
using System.Text;

namespace MusicMarketETicaret.DataAccess.IMainRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository category { get; }
        ICoverTypeRepository coverType { get; }
        ISPCallRepository sp_call { get; }
        void save();
    }
}
