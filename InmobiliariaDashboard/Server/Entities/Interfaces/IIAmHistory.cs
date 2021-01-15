namespace InmobiliariaDashboard.Server.Entities.Interfaces
{
    public interface IIAmHistory<TEntity> : IIdentityFields
        where TEntity : class
    {
        int OriginalId { get; set; }
        TEntity Original { get; set; }
    }
}