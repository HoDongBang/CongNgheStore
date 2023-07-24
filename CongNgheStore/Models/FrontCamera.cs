using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace CongNgheStore.Models
{
    public class FrontCamera
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Độ phân giải")]
        public string Resolution { get; set; }

        [Display(Name = "Tính năng")]
        public string Feature { get; set; }

        //relationship
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
