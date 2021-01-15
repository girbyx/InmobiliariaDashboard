using System.Collections.Generic;
using System.Threading.Tasks;
using InmobiliariaDashboard.Shared.ViewModels;

namespace InmobiliariaDashboard.Client.Shared.Services
{
    public interface IBaseDependentService
    {
        Task<bool> EmailProjectInformation(SendProjectInformationViewModel id);
        Task<IEnumerable<ProjectViewModel>> GetProjectsByEnterprise(int id);
        Task<IEnumerable<BankAccountViewModel>> GetMonetaryAgentsByEnterprise(int id);
        Task<IEnumerable<BankAccountViewModel>> GetMonetaryAgentsByProject(int id);
    }
}