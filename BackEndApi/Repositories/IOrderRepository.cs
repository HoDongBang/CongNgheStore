using CongNgheStore.Models.ViewModel;
using System;

namespace BackEndApi.Repositories
{
    public interface IOrderRepository
    {
        OrderVM GetById(Guid id);
        Guid Add(OrderVM order);
    }
}
