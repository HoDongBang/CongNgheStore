using System;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class DetailVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        //relationship

        public ColorVM Color { get; set; }
        public MemoryAndStorageVM MemoryAndStorage { get; set; }
        public OrderVM Order { get; set; }
        public ProductVM Product { get; set; }
    }
}
