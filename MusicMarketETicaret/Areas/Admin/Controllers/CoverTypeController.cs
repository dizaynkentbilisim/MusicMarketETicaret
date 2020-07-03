using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicMarketETicaret.DataAccess.IMainRepository;
using MusicMarketETicaret.Models.DbModels;

namespace MusicMarketETicaret.Areas.Admin.Controllers
{
  
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        #region Variables
        private readonly IUnitOfWork _uow;
        #endregion

        #region CTOR
        public CoverTypeController(IUnitOfWork uow)
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
            var allObj = _uow.coverType.GetAll();
            return Json(new { data = allObj });

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleteData = _uow.coverType.Get(id);
            if (deleteData == null)
            {
                return Json(new { success = false, message = "Data Not Fond!" });
            }
            else
            {
                _uow.coverType.Remove(deleteData);
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
            CoverType cat = new CoverType();
            if (id == null)
            {
                //This For Create
                return View(cat);
            }
            cat = _uow.coverType.Get((int)id);
            if (cat != null)
            {
                return View(cat);
            }
            return NotFound();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {

            if (ModelState.IsValid)
            {
                if (coverType.Id == 0)
                {
                    //create
                    _uow.coverType.Add(coverType);
                }
                else
                {
                    //Update
                    _uow.coverType.Update(coverType);
                }
                _uow.save();
                return RedirectToAction("Index");
            }
            return View(coverType);
        }
    }
}
