using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên thương hiệu")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [DefaultValue(false)]
        public bool IsRemove { get; set; }

        public string UrlHandle { get; set; }

        //relationship
        public ICollection<BrandCategory> BrandCategories { get; set; }
    }
}
