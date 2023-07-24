using BackEndApi.Model;
using CongNgheStore.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace BackEndApi.Repositories
{
    public interface IProductRepository
    {
        List<ProductVM> GetAll();
        List<ProductVM> GetByBrandCategoty(string? brandUrlHandle, string? categoryUrlHandle, string? price, string? sort, int quantity);

        ProductVM GetById(Guid id);
        List<ProductVM> GetBySearch(string value, int quantity);
    }
}
