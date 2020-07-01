using Microsoft.AspNetCore.Mvc;
using MusicMarketETicaret.DataAccess.IMainRepository;
using MusicMarketETicaret.DataAccess.MainRepository;
using MusicMarketETicaret.Models.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MusicMarketETicaret.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        #region Variables
        private readonly IUnitOfWork _uow;
        #endregion

        #region CTOR
        public CategoryController(IUnitOfWork uow)
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
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleteData = _uow.category.Get(id);
            if (deleteData == null)
            {
                return Json(new { success = false, message = "Data Not Fond!" });
            }
            else 
            {
                _uow.category.Remove(deleteData);
                _uow.save();
                return Json(new { success = true, message = "Data Delete Okey !" });
            }
        }
        #endregion

        /// <summary>
        /// Create or Update Get Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category</returns>
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Category cat = new Category();
            if (id == null)
            {
                //This For Create
                return View(cat);
            }
            cat = _uow.category.Get((int)id);
            if (cat != null)
            {
                return View(cat);
            }
            return NotFound();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(Category category)
        {

            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    //create
                    _uow.category.Add(category);
                }
                else
                {
                    //Update
                    _uow.category.Update(category);
                }
                _uow.save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

    }
}
