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
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Models.Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<CostType> CostTypes { get; set; }
        public DbSet<Gain> Gains { get; set; }
        public DbSet<GainType> GainTypes { get; set; }
        public DbSet<Loss> Losses { get; set; }
        public DbSet<LossType> LossTypes { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasOne(p => p.Client).WithMany(b => b.Accounts).IsRequired();
            modelBuilder.Entity<Account>().HasMany(p => p.Gains).WithOne(b => b.Account);
            modelBuilder.Entity<Account>().HasMany(p => p.Costs).WithOne(b => b.Account);
            modelBuilder.Entity<Account>().HasMany(p => p.Losses).WithOne(b => b.Account);

            modelBuilder.Entity<Attachment>().HasOne(p => p.Gain).WithMany(b => b.Attachments);
            modelBuilder.Entity<Attachment>().HasOne(p => p.Cost).WithMany(b => b.Attachments);
            modelBuilder.Entity<Attachment>().HasOne(p => p.Loss).WithMany(b => b.Attachments);

            modelBuilder.Entity<Models.Client>().HasMany(p => p.Projects).WithOne(b => b.Client);
            modelBuilder.Entity<Models.Client>().HasMany(p => p.Contacts).WithOne(b => b.Client);
            modelBuilder.Entity<Models.Client>().HasMany(p => p.Accounts).WithOne(b => b.Client);

            modelBuilder.Entity<Contact>().HasOne(p => p.Client).WithMany(b => b.Contacts).IsRequired();

            modelBuilder.Entity<Cost>().HasOne(p => p.CostType).WithMany(b => b.Costs).IsRequired();
            modelBuilder.Entity<Cost>().HasOne(p => p.Project).WithMany(b => b.Costs).IsRequired();
            modelBuilder.Entity<Cost>().HasOne(p => p.Account).WithMany(b => b.Costs).IsRequired();
            modelBuilder.Entity<Cost>().HasMany(p => p.Attachments).WithOne(b => b.Cost);

            modelBuilder.Entity<Gain>().HasOne(p => p.GainType).WithMany(b => b.Gains).IsRequired();
            modelBuilder.Entity<Gain>().HasOne(p => p.Project).WithMany(b => b.Gains).IsRequired();
            modelBuilder.Entity<Gain>().HasOne(p => p.Account).WithMany(b => b.Gains).IsRequired();
            modelBuilder.Entity<Gain>().HasMany(p => p.Attachments).WithOne(b => b.Gain);

            modelBuilder.Entity<Loss>().HasOne(p => p.LossType).WithMany(b => b.Losses).IsRequired();
            modelBuilder.Entity<Loss>().HasOne(p => p.Project).WithMany(b => b.Losses).IsRequired();
            modelBuilder.Entity<Loss>().HasOne(p => p.Account).WithMany(b => b.Losses).IsRequired();
            modelBuilder.Entity<Loss>().HasMany(p => p.Attachments).WithOne(b => b.Loss);

            modelBuilder.Entity<Project>().HasOne(p => p.Client).WithMany(b => b.Projects).IsRequired();
            modelBuilder.Entity<Project>().HasMany(p => p.Gains).WithOne(b => b.Project);
            modelBuilder.Entity<Project>().HasMany(p => p.Costs).WithOne(b => b.Project);
            modelBuilder.Entity<Project>().HasMany(p => p.Losses).WithOne(b => b.Project);
        }

        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            if (entity is IAuditFields)
            {
                (entity as IAuditFields).Created = DateTime.Now;
                (entity as IAuditFields).CreatedBy = string.Empty;
            }

            return base.Add(entity);
        }

        public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
        {
            if (entity is ISoftDeleteFields)
            {
                (entity as ISoftDeleteFields).Deleted = DateTime.Now;
                (entity as ISoftDeleteFields).DeletedBy = string.Empty;
                (entity as ISoftDeleteFields).SoftDelete = true;
            }

            return base.Remove(entity);
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            if (entity is IAuditFields)
            {
                (entity as IAuditFields).Updated = DateTime.Now;
                (entity as IAuditFields).UpdatedBy = string.Empty;
            }

            return base.Update(entity);
        }
    }
}