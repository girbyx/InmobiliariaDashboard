using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace InmobiliariaDashboard.Client
{
    public interface IBaseCatalogService<TViewModel> where TViewModel : class
    {
        Task<IEnumerable<TViewModel>> GetList();
        Task<TViewModel> Get(int id);
        Task<TViewModel> GetEmpty();
        Task<int> Add(TViewModel record);
        //Task AddFiles(int id, IEnumerable<IFormFile> record);
        Task Delete(int id);
        Task Archive(int id);
        Task Update(TViewModel record);
        Task Return();
    }
}