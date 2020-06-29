using MusicMarketETicaret.Data;
using MusicMarketETicaret.DataAccess.IMainRepository;
using MusicMarketETicaret.Models.DbModels;
using System.Linq;

namespace MusicMarketETicaret.DataAccess.MainRepository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var data = _db.Category.FirstOrDefault(x => x.Id == category.Id);
            if (data != null)
            {
                data.CategoryName = category.CategoryName;
            }
        }
    }
}
