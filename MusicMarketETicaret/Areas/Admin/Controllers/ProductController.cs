﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicMarketETicaret.DataAccess.IMainRepository;
using MusicMarketETicaret.DataAccess.MainRepository;
using MusicMarketETicaret.Models.DbModels;
using MusicMarketETicaret.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MusicMarketETicaret.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        #region Variables
        private readonly IUnitOfWork _uow;
        private readonly IWebHostEnvironment _hostEnvironment;
        #endregion

        #region CTOR
        public ProductController(IUnitOfWork uow, IWebHostEnvironment hostEnvironment)
        {
            _uow = uow;
            _hostEnvironment = hostEnvironment;

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
            var deleteData = _uow.Product.Get(id);
            if (deleteData == null)
            {
                return Json(new { success = false, message = "Data Not Fond!" });
            }
            else
            {
                _uow.Product.Remove(deleteData);
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
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _uow.category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.Id.ToString()
                }),
                CoverTypeList = _uow.coverType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if (id == null)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _uow.Product.Get(id.GetValueOrDefault());
            }
            if (productVM.Product == null)
            {
                return NotFound();
            }
            else
            {
                return View(productVM);
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(Product product)
        {

            if (ModelState.IsValid)
            {
                if (product.Id == 0)
                {
                    //create
                    _uow.Product.Add(product);
                }
                else
                {
                    //Update
                    _uow.Product.Update(product);
                }
                _uow.save();
                return RedirectToAction("Index");
            }
            return View(product);
        }

    }
}
