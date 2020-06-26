using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicMarketETicaret.Models.DbModels
{
   public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Bu Alan Boş Geçilemez.!")]
        [StringLength(100,MinimumLength =2,ErrorMessage ="Min 2 Max 100 Karakter Giriniz.!")]
        public string CategoryName { get; set; }
       }
}
