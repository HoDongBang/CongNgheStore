using CongNgheStore.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace BackEndApi.Repositories
{
    public interface IMemoryAndStorageRepository
    {
        List<MemoryAndStorageVM> GetByProductId(Guid productId, int quantity);
    }
}
