using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Giá nhập")]
        [DefaultValue(0)]
        public long ImportPrice { get; set; }

        [Display(Name = "Giá bán")]
        [DefaultValue(0)]
        public long SellingPrice { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [DefaultValue(false)]
        public bool IsRemove { get; set; }

        //relationship
        public int? BrandCategoryId { get; set; }

        public BrandCategory BrandCategory { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<MemoryAndStorage> MemoryAndStorages { get; set; }

        public virtual BatteryAndCharger? BatteryAndCharger { get; set; }
        public virtual OSAndCPU? OSAndCPU { get; set; }
        public virtual FrontCamera? FrontCamera { get; set; }
        public virtual RearCamera? RearCamera { get; set; }
        public virtual Screen? Screen { get; set; }

        public ICollection<Detail> Details { get; set; }
    }
}
