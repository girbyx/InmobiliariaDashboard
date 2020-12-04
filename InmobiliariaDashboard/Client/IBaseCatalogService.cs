using System.Collections.Generic;
using System.Threading.Tasks;

namespace InmobiliariaDashboard.Client
{
    public interface IBaseCatalogService<T> where T : class
    {
        Task<IEnumerable<T>> GetList();
        Task<T> Get(int id);
        Task Add(T record);
        Task Delete(int id);
        Task Update(T record);
        Task Return();
    }
}