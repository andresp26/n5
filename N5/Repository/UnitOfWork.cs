using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace RepositoryUsingEFinMVC.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly N5DbContext _context;
        public IPermissionRepository Permission { get; private set; }

        public IPermissionTypeRepository PermissionType { get; private set; }
        public UnitOfWork(N5DbContext context)
        {
            _context = context;
            Permission = new PermissionRepository(context);
            PermissionType = new PermissionTypeRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }

}