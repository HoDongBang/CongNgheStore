using CongNgheStore.Models.DbContext_Folder;
using CongNgheStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEndApi.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private readonly CongNgheStoreDBContext _context;

        public ColorRepository(CongNgheStoreDBContext context)
        {
            _context = context;
        }
        public List<ColorVM> GetByProductId(Guid productId, int quantity)
        {
            var color = _context.Colors.Where(c => c.ProductId == productId).AsQueryable();

            if (quantity > 0)
                color = color.Take(quantity);

            var data = color.Select(c => new ColorVM
            {
                Id = c.Id,
                Name = c.Name,
                Img = c.Img,
                Price = c.Price,
                ProductId = c.ProductId
            }).OrderBy(c => c.Price).ThenBy(c => c.Id);
            
            return data.ToList();
        }
    }
}
