using System.Collections.Generic;

namespace InmobiliariaDashboard.Server.Entities.Interfaces
{
    public interface IHasHistory<TEntity, THistory>
        where TEntity : class
        where THistory : IIAmHistory<TEntity>
    {
        ICollection<THistory> History { get; set; }
    }
}