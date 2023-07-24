using CongNgheStore.Models;
using CongNgheStore.Models.DbContext_Folder;
using System.Collections.Generic;
using System.Linq;

namespace BackEndApi.Repositories
{
    public class SlideRepository : ISlideRepository
    {
        private readonly CongNgheStoreDBContext _context;
        public SlideRepository(CongNgheStoreDBContext context)
        {
            _context = context;
        }
        public List<Slide> GetAll()
        {
            return _context.Slides.Select(s => s).ToList();
        }
    }
}
