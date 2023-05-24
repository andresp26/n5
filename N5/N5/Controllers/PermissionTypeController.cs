using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace N5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPermissions()
        {
            var permissions = await _unitOfWork.PermissionType.All();
            return Ok(permissions);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermission(PermissionType permission)
        {
            if (ModelState.IsValid)
            {

                await _unitOfWork.PermissionType.Upsert(permission);
                await _unitOfWork.CompleteAsync();

                return new JsonResult("Created") { StatusCode = 201 };
            }

            return new JsonResult("Somethign Went wrong") { StatusCode = 500 };
        }

    }
}
