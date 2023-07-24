using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class ProductVM
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

        public BrandVM Brand { get; set; }

        public CategoryVM Category { get; set; }

        //relationship

        public ICollection<ColorVM>? Colors { get; set; }
        public ICollection<MemoryAndStorageVM>? MemoryAndStorages { get; set; }

        public BatteryAndChargerVM? BatteryAndCharger { get; set; }
        public OSAndCPUVM? OSAndCPU { get; set; }
        public FrontCameraVM? FrontCamera { get; set; }
        public RearCameraVM? RearCamera { get; set; }
        public ScreenVM? Screen { get; set; }
    }
}
