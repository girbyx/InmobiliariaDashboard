using System.Collections.Generic;
using System.Threading.Tasks;

namespace InmobiliariaDashboard.Client
{
    public interface IBaseCatalogService<TViewModel> where TViewModel : class
    {
        Task<IEnumerable<TViewModel>> GetList();
        Task<TViewModel> Get(int id);
        Task<TViewModel> GetEmpty();
        Task Add(TViewModel record);
        Task Delete(int id);
        Task Update(TViewModel record);
        Task Return();
    }
}