using System.ComponentModel.DataAnnotations;

namespace MusicMarketETicaret.Models.DbModels
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Cover Type")]
        public string Name { get; set; }
    }
}
