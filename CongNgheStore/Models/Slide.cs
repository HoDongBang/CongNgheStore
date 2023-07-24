using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models
{
    public class Slide
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên file ảnh")]
        public string Img { get; set; }
    }
}
