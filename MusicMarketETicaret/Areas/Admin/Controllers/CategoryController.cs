using Microsoft.AspNetCore.Mvc;
using MusicMarketETicaret.DataAccess.MainRepository;
using MusicMarketETicaret.Models.DbModels;
using System.Collections.Generic;
using System.Linq;

namespace MusicMarketETicaret.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class CategoryController : Controller
    {
        #region Variables
        private readonly UnitOfWork _uow;
        #endregion

        #region CTOR
        public CategoryController(UnitOfWork uow)
        {
            _uow = uow;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {

            return View();
        }
        #endregion

        #region API CALLS
        public IActionResult GetAll()
        {
            var allObj = _uow.category.GetAll();
            return Json(new { data = allObj });

        }
        #endregion
    }
}
