using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace InmobiliariaDashboard.Client
{
    public interface IBaseCatalogService<TViewModel> where TViewModel : class
    {
        Task<IEnumerable<TViewModel>> GetList();
        Task<TViewModel> Get(int id);
        Task<TViewModel> GetEmpty();
        Task<int> Add(TViewModel record);
        Task AddFiles(int id, IBrowserFile[] files);
        Task Delete(int id);
        Task Archive(int id);
        Task<int> Update(TViewModel record);
        Task Return();
    }
}