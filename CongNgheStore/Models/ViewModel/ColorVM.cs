using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models.ViewModel
{
    public class ColorVM
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
    }
}
