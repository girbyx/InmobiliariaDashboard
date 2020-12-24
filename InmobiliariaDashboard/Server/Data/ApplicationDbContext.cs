using System;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Server.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InmobiliariaDashboard.Server.Data
{
    public interface IApplicationDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Archive<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<CostType> CostTypes { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Gain> Gains { get; set; }
        public DbSet<GainType> GainTypes { get; set; }
        public DbSet<Loss> Losses { get; set; }
        public DbSet<LossType> LossTypes { get; set; }
        public DbSet<MonetaryAgent> MonetaryAgents { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectHistory> ProjectsHistory { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            if (entity is IAuditFields)
            {
                (entity as IAuditFields).CreatedOn = DateTime.Now;
                (entity as IAuditFields).CreatedBy = string.Empty;
            }

            return base.Add(entity);
        }

        public EntityEntry<TEntity> Archive<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity is ICanBeArchived)
            {
                (entity as ICanBeArchived).Archived = true;
                (entity as ICanBeArchived).ArchivedOn = DateTime.Now;
                (entity as ICanBeArchived).ArchivedBy = string.Empty;
            }

            return Update(entity);
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            if (entity is IAuditFields)
            {
                (entity as IAuditFields).UpdatedOn = DateTime.Now;
                (entity as IAuditFields).UpdatedBy = string.Empty;
            }

            return base.Update(entity);
        }
    }
}