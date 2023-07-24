using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class CategoryVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên phân loại")]
        public string Name { get; set; }

        public string UrlHandle { get; set; }

        //relationship
        public ICollection<BrandVM> Brands { get; set; }
    }
}
