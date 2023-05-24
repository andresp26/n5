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
    public class PermissionTypeRepository : GenericRepository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(N5DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<PermissionType>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<PermissionType>();
            }
        }
       
        public  async Task<bool> Upsert(PermissionType element)
        {
            try
            {               
                return await Add(element);
                            
            }
            catch (Exception ex)
            {
               return false;
            }

        }
    }
    }