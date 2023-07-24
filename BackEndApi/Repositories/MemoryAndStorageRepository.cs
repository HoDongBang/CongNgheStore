using CongNgheStore.Models.DbContext_Folder;
using CongNgheStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEndApi.Repositories
{
    public class MemoryAndStorageRepository : IMemoryAndStorageRepository
    {
        private readonly CongNgheStoreDBContext _context;

        public MemoryAndStorageRepository(CongNgheStoreDBContext context)
        {
            _context = context;
        }
        public List<MemoryAndStorageVM> GetByProductId(Guid productId, int quantity)
        {
            var memoryAndStorage = _context.MemoryAndStorages.Where(ms => ms.ProductId == productId).AsQueryable();

            if (quantity > 0)
                memoryAndStorage = memoryAndStorage.Take(quantity);

            var data = memoryAndStorage.Select(ms => new MemoryAndStorageVM
            {
                Id = ms.Id,
                Ram = ms.Ram,
                Rom = ms.Rom,
                HardDrive = ms.HardDrive,
                HardDriveType = ms.HardDriveType,
                Price = ms.Price,
                ProductId = ms.ProductId
            }).OrderBy(ms => ms.Price).ThenBy(ms => ms.Id);

            return data.ToList();
        }
    }
}
