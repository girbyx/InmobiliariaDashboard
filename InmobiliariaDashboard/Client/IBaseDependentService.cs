using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Client
{
    public interface IBaseDependentService
    {
        Task<IEnumerable<MonetaryAgentViewModel>> GetMonetaryAgentsByProject(int id);
    }
}