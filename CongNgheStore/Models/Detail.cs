using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models
{
    public class Detail
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Số lượng")]
        [DefaultValue(1)]
        public int Quantity { get; set; }

        //relationship
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? MemoryAndStorageId { get; set; }

        public Color Color { get; set; }
        public MemoryAndStorage MemoryAndStorage { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
