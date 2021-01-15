using System;
using InmobiliariaDashboard.Server.Models;
using InmobiliariaDashboard.Server.Models.Interfaces;
using InmobiliariaDashboard.Shared.Resolvers;
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
        private readonly UserResolverService _userResolver;

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
        public DbSet<LoginUser> LoginUsers { get; set; }

        public ApplicationDbContext(DbContextOptions options, UserResolverService userResolver)
            : base(options)
        {
            _userResolver = userResolver;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<AssetType>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<Attachment>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<Contact>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<Cost>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<CostType>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<Enterprise>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<Gain>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<GainType>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<Loss>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<LossType>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<MonetaryAgent>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<Project>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<ProjectHistory>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());
            modelBuilder.Entity<Reminder>().HasQueryFilter(p => p.CreatedBy == _userResolver.GetCurrentUserName());

            // base users
            modelBuilder.Entity<LoginUser>().HasData(new LoginUser { Id = 1, Username = "admin", Password = "admin", Email = "admin@admin.com", CreatedOn = DateTime.Now, CreatedBy = "system" });
            modelBuilder.Entity<LoginUser>().HasData(new LoginUser { Id = 2, Username = "mdominguez", Password = "gorillaz1", Email = "marco.3292@gmail.com", CreatedOn = DateTime.Now, CreatedBy = "system" });
            modelBuilder.Entity<LoginUser>().HasData(new LoginUser { Id = 3, Username = "ngutierrez", Password = "guayas1", Email = "noe.gutierrez90@gmail.com", CreatedOn = DateTime.Now, CreatedBy = "system" });

            base.OnModelCreating(modelBuilder);
        }

        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            if (entity is IAuditFields fields)
            {
                fields.CreatedOn = DateTime.Now;
                fields.CreatedBy = _userResolver.GetCurrentUserName();
            }

            return base.Add(entity);
        }

        public EntityEntry<TEntity> Archive<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity is ICanBeArchived archived)
            {
                archived.Archived = true;
                archived.ArchivedOn = DateTime.Now;
                archived.ArchivedBy = _userResolver.GetCurrentUserName();
            }

            return Update(entity);
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            if (entity is IAuditFields fields)
            {
                fields.CreatedOn = DateTime.Now;
                fields.CreatedBy = _userResolver.GetCurrentUserName();
                fields.UpdatedOn = DateTime.Now;
                fields.UpdatedBy = _userResolver.GetCurrentUserName();
            }

            return base.Update(entity);
        }
    }
}