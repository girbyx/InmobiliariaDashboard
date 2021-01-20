using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Entities;
using InmobiliariaDashboard.Shared;
using InmobiliariaDashboard.Shared.Enumerations;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface IGainService : IBaseService<Gain, object>
    {
    }

    public class GainService : BaseService<Gain, object>, IGainService
    {
        private const string TransferenceGuessLower = "transferencia";
        private const string TransferenceGuess = "Transferencia";

        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GainService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration)
            : base(dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override int Save(Gain entity, out int id)
        {
            if (entity.Id == 0)
                _dbContext.Add(entity);
            else
                _dbContext.Update(entity);

            _dbContext.SaveChanges();
            id = entity.Id;

            if (entity.Transfer)
            {
                var cost = _mapper.Map<Cost>(entity);

                // check transfer type
                var costType = _dbContext.Set<GainType>()
                    .FirstOrDefault(x => x.Name.ToLower() == TransferenceGuessLower ||
                                         x.Description.ToLower().Contains(TransferenceGuessLower));

                if (costType == null)
                {
                    var newCostType = new CostType { Name = TransferenceGuess, Description = TransferenceGuess };
                    _dbContext.Add(newCostType);
                    _dbContext.SaveChanges();
                    cost.CostTypeId = newCostType.Id;
                }
                else
                    cost.CostTypeId = costType.Id;

                cost.CommissionType = CommissionTypeEnum.Money.Code;
                cost.BankAccountId = entity.CostBankAccountId ?? 0;
                cost.GainBankAccountId = entity.Id;

                _dbContext.Add(cost);
            }

            return _dbContext.SaveChanges();
        }

        public override int SaveAttachments(string[] files, int costId)
        {
            if (files != null && files.Any())
            {
                return SaveToFileHosting(files, costId, Constants.CostFolderPath);
            }

            return 0;
        }
    }
}