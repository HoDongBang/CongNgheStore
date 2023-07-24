using CongNgheStore.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace BackEndApi.Repositories
{
    public interface IColorRepository
    {
        List<ColorVM> GetByProductId(Guid productId, int quantity);
    }
}
