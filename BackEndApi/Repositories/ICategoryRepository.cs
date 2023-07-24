using CongNgheStore.Models;
using CongNgheStore.Models.ViewModel;
using System.Collections.Generic;

namespace BackEndApi.Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryVM> GetAll();
        CategoryVM GetByUrlHandle(string urlHandle);
    }
}
