using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Client
{
    public interface IBaseDependentService
    {
        Task<bool> EmailProjectInformation(SendProjectInformationViewModel id);
        Task<IEnumerable<MonetaryAgentViewModel>> GetMonetaryAgentsByProject(int id);
    }
}