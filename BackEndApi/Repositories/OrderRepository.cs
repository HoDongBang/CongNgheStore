using CongNgheStore.Models;
using CongNgheStore.Models.DbContext_Folder;
using CongNgheStore.Models.ViewModel;
using System;
using System.Linq;

namespace BackEndApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CongNgheStoreDBContext _context;

        public OrderRepository(CongNgheStoreDBContext context)
        {
            _context = context;
        }

        public OrderVM GetById(Guid id)
        {
            var data = _context.Orders.SingleOrDefault(o => o.Id == id);
            if (data != null)
            {
                return new OrderVM
                {
                    Id = data.Id,
                    PhoneNumber = data.PhoneNumber,
                    Name = data.Name,
                    Address = data.Address,
                    CustomerNotes = data.CustomerNotes,
                    StoreNotes = data.StoreNotes,
                    Date = data.Date,
                    Status = data.Status,

                    User = _context.Users.Select(u => new UserVM
                    {
                        Id = u.Id,
                        PhoneNumber = u.PhoneNumber,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Password = null,
                        RoleId = null
                    }).SingleOrDefault(u => u.Id == data.UserId),

                    Details = _context.Details.Where(d => d.OrderId == data.Id)
                                                    .Select(d => new DetailVM
                                                    {
                                                        Id = d.Id,
                                                        Quantity = d.Quantity,
                                                        Product = _context.Products
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
                                                            }
                                                        }).SingleOrDefault(p => p.Id == d.ProductId),
                                                        Color = _context.Colors.Select(c => new ColorVM
                                                        {
                                                            Id = c.Id,
                                                            Name = c.Name,
                                                            Img = c.Img,
                                                            Price = c.Price,
                                                            ProductId = c.ProductId
                                                        }).SingleOrDefault(c => c.Id == d.ColorId),
                                                        MemoryAndStorage = _context.MemoryAndStorages.Select(ms => new MemoryAndStorageVM
                                                        {
                                                            Id = ms.Id,
                                                            Ram = ms.Ram,
                                                            Rom = ms.Rom,
                                                            HardDrive = ms.HardDrive,
                                                            HardDriveType = ms.HardDriveType,
                                                            Price = ms.Price,
                                                            ProductId = ms.ProductId
                                                        }).SingleOrDefault(ms => ms.Id == d.MemoryAndStorageId),
                                                    }).ToList()
                };
            }
            return null;
        }

        public Guid Add(OrderVM order)
        {
            //order
            var data = new Order {
                Id = Guid.NewGuid(),
                PhoneNumber = order.PhoneNumber,
                Name = order.Name,
                Address = order.Address,
                CustomerNotes = order.CustomerNotes,
                StoreNotes = order.StoreNotes,
                Date = order.Date,
                Status = "Chờ xác nhận",
                UserId = order.UserId
            };
            _context.Orders.Add(data);
            _context.SaveChanges();

            //detail
            var details = order.Details.ToList();
            for (var i = 0; i < details.Count(); i++)
            {
                var quantity = details[i].Quantity;
                if (quantity > 0)
                {
                    var detail = new Detail
                    {
                        Quantity = details[i].Quantity,
                        OrderId = data.Id,
                        ProductId = details[i].Product.Id,
                        ColorId = details[i].Color.Id,
                        MemoryAndStorageId = details[i].MemoryAndStorage.Id
                    };
                    _context.Details.Add(detail);
                    _context.SaveChanges();
                }
            }    
            return data.Id;
        }
    }
}
