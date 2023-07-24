using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên màu")]
        public string Name { get; set; }

        [Display(Name = "Tên file ảnh")]
        public string Img { get; set; }

        [Display(Name = "Giá")]
        [DefaultValue(0)]
        public long Price { get; set; }

        //relationship
        public Guid? ProductId { get; set; }

        public Product Product { get; set; }
        public ICollection<Detail> Details { get; set; }
    }
}
