using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CongNgheStore.Models
{
    public class BrandCategory
    {
        [Key]
        public int Id { get; set; }

        //relationship
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
