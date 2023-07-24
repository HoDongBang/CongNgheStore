using CongNgheStore.Models;
using CongNgheStore.Models.DbContext_Folder;
using CongNgheStore.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace BackEndApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CongNgheStoreDBContext _context;

        public CategoryRepository(CongNgheStoreDBContext context)
        {
            _context = context;
        }
        public List<CategoryVM> GetAll()
        {
            var data = _context.Categories.Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name,
                UrlHandle = c.UrlHandle,

                Brands = _context.Brands.Where(b => b.IsRemove == false).Join(_context.BrandCategories
                            .Where(bc => bc.CategoryId == c.Id), b => b.Id, bc => bc.BrandId,(tb1, tb2) =>
                            new BrandVM
                            {
                                Id = tb1.Id,
                                Name = tb1.Name,
                                Description = tb1.Description,
                                UrlHandle = tb1.UrlHandle
                            }
                        ).ToList()
            });
            return data.ToList();
        }

        public CategoryVM GetByUrlHandle(string urlHandle)
        {
            var data = _context.Categories.SingleOrDefault(c => c.UrlHandle == urlHandle);
            if (data != null)
            {
                return new CategoryVM
                {
                    Id = data.Id,
                    Name = data.Name,
                    UrlHandle = data.UrlHandle,

                    Brands = _context.Brands.Where(b => b.IsRemove == false).Join(_context.BrandCategories
                            .Where(bc => bc.CategoryId == data.Id), b => b.Id, bc => bc.BrandId, (tb1, tb2) =>
                            new BrandVM
                            {
                                Id = tb1.Id,
                                Name = tb1.Name,
                                Description = tb1.Description,
                                UrlHandle = tb1.UrlHandle
                            }
                        ).ToList()
                };
            }
            return null;
        }
    }
}
