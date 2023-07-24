using CongNgheStore.Models;
using CongNgheStore.Models.DbContext_Folder;
using CongNgheStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEndApi.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly CongNgheStoreDBContext _context;
        public BrandRepository(CongNgheStoreDBContext context)
        {
            _context = context;
        }
        public List<BrandVM> GetAll()
        {
            var data = _context.Brands.Where(b => b.IsRemove == false).Select(b => new BrandVM
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,

                Categories = _context.Categories.Join(_context.BrandCategories
                            .Where(bc => bc.BrandId == b.Id), c => c.Id, bc => bc.CategoryId, (tb1, tb2) =>
                            new CategoryVM
                            {
                                Id = tb1.Id,
                                Name = tb1.Name,
                                UrlHandle = tb1.UrlHandle
                            }
                        ).ToList()
            });
            return data.ToList();
        }
        public BrandVM GetByProductId(Guid productId)
        {
            var brand = _context.Brands.Where(b => b.IsRemove == false)
                            .Join(_context.BrandCategories, b => b.Id, bc => bc.BrandId,
                            (b, bc) => new { b, bc })
                            .Join(_context.Products, bbc => bbc.bc.Id, p => p.BrandCategoryId,
                            (bbc, p) => new { bbc, p })
                            .AsQueryable();
            
            var data = brand.SingleOrDefault(b => b.p.Id == productId);

            if (data != null)
            {
                return new BrandVM
                {
                    Id = data.bbc.b.Id,
                    Name = data.bbc.b.Name,
                    Description = data.bbc.b.Description,
                    UrlHandle = data.bbc.b.UrlHandle
                };
            }
            return null;    
        }

        public BrandVM GetByUrlHandle(string urlHandle)
        {
            var date = _context.Brands.SingleOrDefault(c => c.UrlHandle == urlHandle);
            if (date != null)
            {
                return new BrandVM
                {
                    Id = date.Id,
                    Name = date.Name,
                    UrlHandle = date.UrlHandle,

                    Categories = _context.Categories.Join(_context.BrandCategories
                            .Where(bc => bc.BrandId == date.Id), c => c.Id, bc => bc.CategoryId, (tb1, tb2) =>
                            new CategoryVM
                            {
                                Id = tb1.Id,
                                Name = tb1.Name,
                                UrlHandle = tb1.UrlHandle
                            }
                        ).ToList()
                };
            }
            return null;
        }
    }
}
