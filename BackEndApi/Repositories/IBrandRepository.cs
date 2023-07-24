using CongNgheStore.Models;
using CongNgheStore.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace BackEndApi.Repositories
{
    public interface IBrandRepository
    {
        List<BrandVM> GetAll();
        BrandVM GetByProductId(Guid productId);
        BrandVM GetByUrlHandle(string urlHandle);
    }
}
