using System.Linq;
using AutoMapper;
using InmobiliariaDashboard.Server.Data;
using InmobiliariaDashboard.Server.Entities;
using InmobiliariaDashboard.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InmobiliariaDashboard.Server.Services
{
    public interface ICostService : IBaseService<Cost, object>
    {
    }

    public class CostService : BaseService<Cost, object>, ICostService
    {
        private const string TransferenceGuessLower = "transferencia";
        private const string TransferenceGuess = "Transferencia";

        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CostService(IApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration)
            : base(dbContext, mapper, configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override int Save(Cost entity, out int id)
        {
            if (entity.Id == 0)
                _dbContext.Add(entity);
            else
                _dbContext.Update(entity);

            _dbContext.SaveChanges();
            id = entity.Id;

            if (entity.Transfer)
            {
                var gain = _mapper.Map<Gain>(entity);

                // check transfer type
                var gainType = _dbContext.Set<GainType>()
                    .FirstOrDefault(x => x.Name.ToLower() == TransferenceGuessLower ||
                                         x.Description.ToLower().Contains(TransferenceGuessLower));

                if (gainType == null)
                {
                    var newGainType = new GainType { Name = TransferenceGuess, Description = TransferenceGuess };   
                    _dbContext.Add(newGainType);
                    _dbContext.SaveChanges();
                    gain.GainTypeId = newGainType.Id;
                }
                else
                    gain.GainTypeId = gainType.Id;

                gain.BankAccountId = entity.GainBankAccountId ?? 0;
                gain.CostBankAccountId = entity.Id;

                _dbContext.Add(gain);
            }

            return _dbContext.SaveChanges();
        }

        public override Cost Get(int id)
        {
            var records = _dbContext.Set<Cost>()
                .Include(x => x.BankAccount)
                .Include(x => x.Attachments)
                .Single(x => x.Id == id);
            return records;
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