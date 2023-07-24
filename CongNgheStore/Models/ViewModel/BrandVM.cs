using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class BrandVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên thương hiệu")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public string UrlHandle { get; set; }


        //relationship
        public ICollection<CategoryVM> Categories { get; set; }
    }
}
