using System.Collections.Generic;

namespace InmobiliariaDashboard.Server.Models.Interfaces
{
    public interface IHaveHistory<TEntity, THistory>
        where TEntity : class
        where THistory : IIAmHistory<TEntity>
    {
        ICollection<THistory> History { get; set; }
    }
}