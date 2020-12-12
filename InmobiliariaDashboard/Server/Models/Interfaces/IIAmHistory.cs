namespace InmobiliariaDashboard.Server.Models.Interfaces
{
    public interface IIAmHistory<TEntity>
        where TEntity : class
    {
        int Id { get; set; }
        int OriginalId { get; set; }
        TEntity Original { get; set; }
    }
}