using CongNgheStore.Models;
using System.Collections.Generic;

namespace BackEndApi.Repositories
{
    public interface ISlideRepository
    {
        List<Slide> GetAll();
    }
}
