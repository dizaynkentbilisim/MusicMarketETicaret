using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using MusicMarketETicaret.DataAccess.IMainRepository;
using MusicMarketETicaret.Models.DbModels;
using MusicMarketETicaret.Utility;

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
            // var allObj = _uow.coverType.GetAll();
            var allCoverTypes = _uow.sp_call.List<CoverType>(PorojectConstant.Proc_CoverType_GetAll, null);
            return Json(new { data = allCoverTypes });

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            // var deleteData = _uow.coverType.Get(id);
            //if (deleteData == null)
            //{
            //  return Json(new { success = false, message = "Data Not Fond!" });
            //}
            //else
            //{
            //  _uow.coverType.Remove(deleteData);
            //_uow.save();
            //return Json(new { success = true, message = "Data Delete Okey !" });
            //}

            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);

            var deleteData = _uow.sp_call.OneRecord<CoverType>(PorojectConstant.Proc_CoverType_Get, parameter);
            if (deleteData == null)
            {
                return Json(new { success = false, message = "Data Not Fond!" });
            }
            else
            {
                _uow.sp_call.Execute(PorojectConstant.Proc_CoverType_Delete, parameter);
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
            CoverType coverType = new CoverType();
            if (id == null)
            {
                //This For Create
                return View(coverType);
            }
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            coverType = _uow.sp_call.OneRecord<CoverType>(PorojectConstant.Proc_CoverType_Get, parameter);

            //coverType = _uow.coverType.Get((int)id);
            if (coverType != null)
            {
                return View(coverType);
            }
            return NotFound();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {

            if (ModelState.IsValid)
            {
                var parameter = new DynamicParameters();
                parameter.Add("Name", coverType.Name);

                if (coverType.Id == 0)
                {
                    //create
                    // _uow.coverType.Add(coverType);

                    _uow.sp_call.Execute(PorojectConstant.Proc_CoverType_Create, parameter);
                }
                else
                {
                    //Update
                    // _uow.coverType.Update(coverType);
                    parameter.Add("@Id", coverType.Id);
                    _uow.sp_call.Execute(PorojectConstant.Proc_CoverType_Update, parameter);
                }
                _uow.save();
                return RedirectToAction("Index");
            }
            return View(coverType);
        }
    }
}
