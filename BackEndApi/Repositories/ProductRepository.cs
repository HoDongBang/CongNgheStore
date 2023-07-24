using BackEndApi.Model;
using CongNgheStore.Models;
using CongNgheStore.Models.DbContext_Folder;
using CongNgheStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Color = CongNgheStore.Models.Color;

namespace BackEndApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CongNgheStoreDBContext _context;

        public ProductRepository(CongNgheStoreDBContext context)
        {
            _context = context;
        }

        public List<ProductVM> GetAll()
        {
            var productVMs = _context.Products.Where(p => p.IsRemove == false).Select(p => new ProductVM
                            {
                                Id = p.Id,
                                Name = p.Name,
                                ImportPrice = p.ImportPrice,
                                SellingPrice = p.SellingPrice,
                                Date =  p.Date,
                                Description = p.Description
                            }).OrderByDescending(p => p.Date);
            return productVMs.ToList();
        }

        public List<ProductVM> GetByBrandCategoty(string? brandUrlHandle, string? categoryUrlHandle, string? price, string? sort, int quantity)
        {
            var productVMs = _context.Products.Where(p => p.IsRemove == false)
                                .Join(_context.BrandCategories, p => p.BrandCategoryId, bc => bc.Id,
                                (p, bc) => new{p, bc})
                                .Join(_context.Brands, pbc => pbc.bc.BrandId, b => b.Id,
                                (pbc, b) => new {pbc, b})
                                .Join(_context.Categories, pbcb => pbcb.pbc.bc.CategoryId,
                                c => c.Id, (pbcb, c) => new {pbcb, c}).OrderByDescending(p => p.pbcb.pbc.p.Date)
                                .AsQueryable();
            if (!string.IsNullOrEmpty(brandUrlHandle))
                productVMs = productVMs.Where(p => p.pbcb.b.UrlHandle == brandUrlHandle);

            if (!string.IsNullOrEmpty(categoryUrlHandle))
                productVMs = productVMs.Where(p => p.c.UrlHandle == categoryUrlHandle);

            if(!string.IsNullOrEmpty(price))
                switch (price)
                {
                    case "T20t": productVMs = productVMs.Where(p => p.pbcb.pbc.p.SellingPrice >= 20000000); break;
                    case "15t-20t": productVMs = productVMs.Where(p => p.pbcb.pbc.p.SellingPrice >= 15000000 && p.pbcb.pbc.p.SellingPrice < 20000000); break;
                    case "10t-15t": productVMs = productVMs.Where(p => p.pbcb.pbc.p.SellingPrice >= 10000000 && p.pbcb.pbc.p.SellingPrice < 15000000); break;
                    case "5t-10t": productVMs = productVMs.Where(p => p.pbcb.pbc.p.SellingPrice >= 5000000 && p.pbcb.pbc.p.SellingPrice < 10000000); break;
                    case "D5t": productVMs = productVMs.Where(p => p.pbcb.pbc.p.SellingPrice < 5000000); break;
                    default: productVMs = productVMs.Where(p => p.pbcb.pbc.p.SellingPrice > 0); break;
                }
            if(!string.IsNullOrEmpty(sort))
                switch (sort)
                {
                    case "m-c": productVMs = productVMs.OrderByDescending(p => p.pbcb.pbc.p.Date); break;
                    case "c-m": productVMs = productVMs.OrderBy(p => p.pbcb.pbc.p.Date); break;
                    case "t-c": productVMs = productVMs.OrderBy(p => p.pbcb.pbc.p.SellingPrice); break;
                    case "c-t": productVMs = productVMs.OrderByDescending(p => p.pbcb.pbc.p.SellingPrice); break;
                } 

            if (quantity > 0)
                productVMs = productVMs.Take(quantity);
            var data = productVMs.Select(p => new ProductVM
            {
                Id = p.pbcb.pbc.p.Id,
                Name = p.pbcb.pbc.p.Name,
                ImportPrice = p.pbcb.pbc.p.ImportPrice,
                SellingPrice = p.pbcb.pbc.p.SellingPrice,
                Date = p.pbcb.pbc.p.Date,
                Description = p.pbcb.pbc.p.Description,

                Brand = new BrandVM
                {
                    Id = p.pbcb.b.Id,
                    Name = p.pbcb.b.Name,
                    Description = p.pbcb.b.Description,
                    UrlHandle = p.pbcb.b.UrlHandle
                },
                Category = new CategoryVM
                {
                    Id = p.c.Id,
                    Name = p.c.Name,
                    UrlHandle = p.c.UrlHandle
                },

                Colors = _context.Colors.Where(c => c.ProductId == p.pbcb.pbc.p.Id)
                                                    .Select(c => new ColorVM
                                                    {
                                                        Id = c.Id,
                                                        Name = c.Name,
                                                        Img = c.Img,
                                                        Price = c.Price,
                                                        ProductId = c.ProductId
                                                    }).OrderBy(c => c.Price).ThenBy(c => c.Id).ToList(),

                MemoryAndStorages = _context.MemoryAndStorages.Where(ms => ms.ProductId == p.pbcb.pbc.p.Id)
                                                                .Select(ms => new MemoryAndStorageVM
                                                                {
                                                                    Id = ms.Id,
                                                                    Ram = ms.Ram,
                                                                    Rom = ms.Rom,
                                                                    HardDrive = ms.HardDrive,
                                                                    HardDriveType = ms.HardDriveType,
                                                                    Price = ms.Price,
                                                                    ProductId = ms.ProductId
                                                                })
                                                                .OrderBy(ms => ms.Price).ThenBy(ms => ms.Id).ToList(),
                BatteryAndCharger = _context.BatteryAndChargers.Select(bc => new BatteryAndChargerVM
                {
                    Id = bc.Id,
                    BatteryCapacity = bc.BatteryCapacity,
                    BatteryType = bc.BatteryType,
                    MaximumChargingSupport = bc.MaximumChargingSupport,
                    BatteryTechnology = bc.BatteryTechnology,
                    ProductId = bc.ProductId
                }).SingleOrDefault(bc => bc.ProductId == p.pbcb.pbc.p.Id),
                OSAndCPU = _context.OSAndCPUs.Select(oc => new OSAndCPUVM
                {
                    Id = oc.Id,
                    OperatingSystem = oc.OperatingSystem,
                    Cpu = oc.Cpu,
                    CpuSpeed = oc.CpuSpeed,
                    Gpu = oc.Gpu,
                    ProductId = oc.ProductId
                }).SingleOrDefault(oc => oc.ProductId == p.pbcb.pbc.p.Id),
                FrontCamera = _context.FrontCameras.Select(f => new FrontCameraVM
                {
                    Id = f.Id,
                    Resolution = f.Resolution,
                    Feature = f.Feature,
                    ProductId = f.ProductId
                }).SingleOrDefault(f => f.ProductId == p.pbcb.pbc.p.Id),
                RearCamera = _context.RearCameras.Select(r => new RearCameraVM
                {
                    Id = r.Id,
                    Resolution = r.Resolution,
                    Film = r.Film,
                    FlashLight = r.FlashLight,
                    Feature = r.Feature,
                    ProductId = r.ProductId
                }).SingleOrDefault(r => r.ProductId == p.pbcb.pbc.p.Id),
                Screen = _context.Screens.Select(s => new ScreenVM
                {
                    Id = s.Id,
                    ScreenTechnology = s.ScreenTechnology,
                    Resolution = s.Resolution,
                    Widescreen = s.Widescreen,
                    MaximumBrightness = s.MaximumBrightness,
                    TouchScreen = s.TouchScreen,
                    ProductId = s.ProductId
                }).SingleOrDefault(s => s.ProductId == p.pbcb.pbc.p.Id),
            });
            return data.ToList();
        }

        public ProductVM GetById(Guid id)
        {
            var data = _context.Products.Where(p => p.IsRemove == false)
                                .Join(_context.BrandCategories, p => p.BrandCategoryId, bc => bc.Id,
                                (p, bc) => new { p, bc })
                                .Join(_context.Brands, pbc => pbc.bc.BrandId, b => b.Id,
                                (pbc, b) => new { pbc, b })
                                .Join(_context.Categories, pbcb => pbcb.pbc.bc.CategoryId,
                                c => c.Id, (pbcb, c) => new { pbcb, c })
                                .Select(p => new ProductVM
                                {
                                    Id = p.pbcb.pbc.p.Id,
                                    Name = p.pbcb.pbc.p.Name,
                                    ImportPrice = p.pbcb.pbc.p.ImportPrice,
                                    SellingPrice = p.pbcb.pbc.p.SellingPrice,
                                    Date = p.pbcb.pbc.p.Date,
                                    Description = p.pbcb.pbc.p.Description,

                                    Brand = new BrandVM
                                    {
                                        Id = p.pbcb.b.Id,
                                        Name = p.pbcb.b.Name,
                                        Description = p.pbcb.b.Description,
                                        UrlHandle = p.pbcb.b.UrlHandle
                                    },
                                    Category = new CategoryVM
                                    {
                                        Id = p.c.Id,
                                        Name = p.c.Name,
                                        UrlHandle = p.c.UrlHandle
                                    },

                                    Colors = _context.Colors.Where(c => c.ProductId == p.pbcb.pbc.p.Id)
                                                    .Select(c => new ColorVM
                                                    {
                                                        Id = c.Id,
                                                        Name = c.Name,
                                                        Img = c.Img,
                                                        Price = c.Price,
                                                        ProductId = c.ProductId
                                                    }).OrderBy(c => c.Price).ThenBy(c => c.Id).ToList(),

                                    MemoryAndStorages = _context.MemoryAndStorages.Where(ms => ms.ProductId == p.pbcb.pbc.p.Id)
                                                                .Select(ms => new MemoryAndStorageVM
                                                                {
                                                                    Id = ms.Id,
                                                                    Ram = ms.Ram,
                                                                    Rom = ms.Rom,
                                                                    HardDrive = ms.HardDrive,
                                                                    HardDriveType = ms.HardDriveType,
                                                                    Price = ms.Price,
                                                                    ProductId = ms.ProductId
                                                                })
                                                                .OrderBy(ms => ms.Price).ThenBy(ms => ms.Id).ToList(),
                                    BatteryAndCharger = _context.BatteryAndChargers.Select(bc => new BatteryAndChargerVM
                                    {
                                        Id = bc.Id,
                                        BatteryCapacity = bc.BatteryCapacity,
                                        BatteryType = bc.BatteryType,
                                        MaximumChargingSupport = bc.MaximumChargingSupport,
                                        BatteryTechnology = bc.BatteryTechnology,
                                        ProductId = bc.ProductId
                                    }).SingleOrDefault(bc => bc.ProductId == p.pbcb.pbc.p.Id),
                                    OSAndCPU = _context.OSAndCPUs.Select(oc => new OSAndCPUVM
                                    {
                                        Id = oc.Id,
                                        OperatingSystem = oc.OperatingSystem,
                                        Cpu = oc.Cpu,
                                        CpuSpeed = oc.CpuSpeed,
                                        Gpu = oc.Gpu,
                                        ProductId = oc.ProductId
                                    }).SingleOrDefault(oc => oc.ProductId == p.pbcb.pbc.p.Id),
                                    FrontCamera = _context.FrontCameras.Select(f => new FrontCameraVM
                                    {
                                        Id = f.Id,
                                        Resolution = f.Resolution,
                                        Feature = f.Feature,
                                        ProductId = f.ProductId
                                    }).SingleOrDefault(f => f.ProductId == p.pbcb.pbc.p.Id),
                                    RearCamera = _context.RearCameras.Select(r => new RearCameraVM
                                    {
                                        Id = r.Id,
                                        Resolution = r.Resolution,
                                        Film = r.Film,
                                        FlashLight = r.FlashLight,
                                        Feature = r.Feature,
                                        ProductId = r.ProductId
                                    }).SingleOrDefault(r => r.ProductId == p.pbcb.pbc.p.Id),
                                    Screen = _context.Screens.Select(s => new ScreenVM
                                    {
                                        Id = s.Id,
                                        ScreenTechnology = s.ScreenTechnology,
                                        Resolution = s.Resolution,
                                        Widescreen = s.Widescreen,
                                        MaximumBrightness = s.MaximumBrightness,
                                        TouchScreen = s.TouchScreen,
                                        ProductId = s.ProductId
                                    }).SingleOrDefault(s => s.ProductId == p.pbcb.pbc.p.Id),
                                })
                                .SingleOrDefault(p => p.Id == id);

            if (data != null)
            {
                return data;
            }
            return null;        
        }

        public List<ProductVM> GetBySearch(string value, int quantity)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            var productVMs = _context.Products.Where(p => p.IsRemove == false && p.Name.Contains(value))
                                .Join(_context.BrandCategories, p => p.BrandCategoryId, bc => bc.Id,
                                (p, bc) => new { p, bc })
                                .Join(_context.Brands, pbc => pbc.bc.BrandId, b => b.Id,
                                (pbc, b) => new { pbc, b })
                                .Join(_context.Categories, pbcb => pbcb.pbc.bc.CategoryId,
                                c => c.Id, (pbcb, c) => new { pbcb, c }).OrderBy(p => p.pbcb.pbc.p.Name)
                                .AsQueryable();

            if (quantity > 0)
                productVMs = productVMs.Take(quantity);

            var data = productVMs.Select(p => new ProductVM
            {
                Id = p.pbcb.pbc.p.Id,
                Name = p.pbcb.pbc.p.Name,
                ImportPrice = p.pbcb.pbc.p.ImportPrice,
                SellingPrice = p.pbcb.pbc.p.SellingPrice,
                Date = p.pbcb.pbc.p.Date,
                Description = p.pbcb.pbc.p.Description,

                Brand = new BrandVM
                {
                    Id = p.pbcb.b.Id,
                    Name = p.pbcb.b.Name,
                    Description = p.pbcb.b.Description,
                    UrlHandle = p.pbcb.b.UrlHandle
                },
                Category = new CategoryVM
                {
                    Id = p.c.Id,
                    Name = p.c.Name,
                    UrlHandle = p.c.UrlHandle
                },

                Colors = _context.Colors.Where(c => c.ProductId == p.pbcb.pbc.p.Id)
                                                    .Select(c => new ColorVM
                                                    {
                                                        Id = c.Id,
                                                        Name = c.Name,
                                                        Img = c.Img,
                                                        Price = c.Price,
                                                        ProductId = c.ProductId
                                                    }).OrderBy(c => c.Price).ThenBy(c => c.Id).ToList(),

                MemoryAndStorages = _context.MemoryAndStorages.Where(ms => ms.ProductId == p.pbcb.pbc.p.Id)
                                                                .Select(ms => new MemoryAndStorageVM
                                                                {
                                                                    Id = ms.Id,
                                                                    Ram = ms.Ram,
                                                                    Rom = ms.Rom,
                                                                    HardDrive = ms.HardDrive,
                                                                    HardDriveType = ms.HardDriveType,
                                                                    Price = ms.Price,
                                                                    ProductId = ms.ProductId
                                                                })
                                                                .OrderBy(ms => ms.Price).ThenBy(ms => ms.Id).ToList(),
                BatteryAndCharger = _context.BatteryAndChargers.Select(bc => new BatteryAndChargerVM
                {
                    Id = bc.Id,
                    BatteryCapacity = bc.BatteryCapacity,
                    BatteryType = bc.BatteryType,
                    MaximumChargingSupport = bc.MaximumChargingSupport,
                    BatteryTechnology = bc.BatteryTechnology,
                    ProductId = bc.ProductId
                }).SingleOrDefault(bc => bc.ProductId == p.pbcb.pbc.p.Id),
                OSAndCPU = _context.OSAndCPUs.Select(oc => new OSAndCPUVM
                {
                    Id = oc.Id,
                    OperatingSystem = oc.OperatingSystem,
                    Cpu = oc.Cpu,
                    CpuSpeed = oc.CpuSpeed,
                    Gpu = oc.Gpu,
                    ProductId = oc.ProductId
                }).SingleOrDefault(oc => oc.ProductId == p.pbcb.pbc.p.Id),
                FrontCamera = _context.FrontCameras.Select(f => new FrontCameraVM
                {
                    Id = f.Id,
                    Resolution = f.Resolution,
                    Feature = f.Feature,
                    ProductId = f.ProductId
                }).SingleOrDefault(f => f.ProductId == p.pbcb.pbc.p.Id),
                RearCamera = _context.RearCameras.Select(r => new RearCameraVM
                {
                    Id = r.Id,
                    Resolution = r.Resolution,
                    Film = r.Film,
                    FlashLight = r.FlashLight,
                    Feature = r.Feature,
                    ProductId = r.ProductId
                }).SingleOrDefault(r => r.ProductId == p.pbcb.pbc.p.Id),
                Screen = _context.Screens.Select(s => new ScreenVM
                {
                    Id = s.Id,
                    ScreenTechnology = s.ScreenTechnology,
                    Resolution = s.Resolution,
                    Widescreen = s.Widescreen,
                    MaximumBrightness = s.MaximumBrightness,
                    TouchScreen = s.TouchScreen,
                    ProductId = s.ProductId
                }).SingleOrDefault(s => s.ProductId == p.pbcb.pbc.p.Id),
            });
            return data.ToList();
        }
    }
}
