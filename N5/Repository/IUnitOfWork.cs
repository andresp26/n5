using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork
    {
        IPermissionRepository Permission { get; }

        IPermissionTypeRepository PermissionType { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
