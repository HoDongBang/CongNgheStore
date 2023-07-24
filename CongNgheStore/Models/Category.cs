using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên phân loại")]
        public string Name { get; set; }

        public string UrlHandle { get; set; }

        //relationship
        public ICollection<BrandCategory> BrandCategories { get; set; }
    }
}
