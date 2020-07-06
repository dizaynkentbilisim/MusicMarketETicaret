using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicMarketETicaret.Models.DbModels
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1,1000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Price { get; set; }
        public double Price50 { get; set; }
        public double Price100 { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int CategryId { get; set; }
        [Required]
        public int CoverTypeId { get; set; }


        [ForeignKey("CategryId")]
        public Category category { get; set; }
        [ForeignKey("CoverTypeId")]
        public CoverType coverType { get; set; }
    }
}
