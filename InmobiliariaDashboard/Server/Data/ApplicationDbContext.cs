﻿using System;
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
        public DbSet<Gain> Gains { get; set; }
        public DbSet<Loss> Losses { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
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