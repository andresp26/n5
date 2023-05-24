using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(N5DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Permission>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Permission>();
            }
        }
        public  async Task<bool> Upsert(Permission entity)
        {
            try
            {
                var existingPermission = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existingPermission == null)
                    return await Add(entity);

                existingPermission.NombreEmpleado = entity.NombreEmpleado;
                existingPermission.ApellidoEmpleado = entity.ApellidoEmpleado;
                existingPermission.FechaPermiso = entity.FechaPermiso;
                existingPermission.TipoPermiso = entity.TipoPermiso;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  async Task<Permission> GetById(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                          .FirstOrDefaultAsync();

                if (exist == null) return null;

                return exist;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
    }