using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using NuGet.Packaging.Core;
using Repository;
using Data;
using RepositoryUsingEFinMVC.UnitOfWork;
using System.Security;
using System.Text.Json.Serialization;

namespace N5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermissionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPermissions()
        {
            var permissions = await _unitOfWork.Permission.All();
            return Ok(permissions);
        }
 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermission(int id)
        {
            var item = await _unitOfWork.Permission.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

      

        [HttpPost]
        public async Task<IActionResult> CreatePermission(Permission permission)
        {
            try
            {
                permission.FechaPermiso = DateTime.Now;
                await _unitOfWork.Permission.Add(permission);
                await _unitOfWork.CompleteAsync();

                return new JsonResult("Created") { StatusCode = 201 };
            }
            catch (Exception ex)
            {   
                return new JsonResult("Somethign Went wrong", ex) { StatusCode = 500 };
            }                               
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var item = await _unitOfWork.Permission.GetById(id);

            if (item == null)
                return BadRequest();

            await _unitOfWork.Permission.Delete(item);
            await _unitOfWork.CompleteAsync();
            
            return    new JsonResult(String.Format("Registro eliminado {0}", item.Id)) { StatusCode = 200 };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermission(int id,Permission obj)
        {
            var item = await _unitOfWork.Permission.GetById(id);

            if (item == null)
                return NotFound();
            await _unitOfWork.Permission.Upsert(obj);                      
            await _unitOfWork.CompleteAsync();

            return new JsonResult(String.Format("Registro actualizado {0}", item.Id)) { StatusCode = 200 };
        }
    }
      
}