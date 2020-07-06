using Microsoft.AspNetCore.Mvc.Rendering;
using MusicMarketETicaret.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicMarketETicaret.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> CoverTypeList { get; set; }
    }
}
