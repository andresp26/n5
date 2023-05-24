using Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using N5.Controllers;
using NuGet.Protocol.Core.Types;
using Repository;
using RepositoryUsingEFinMVC.UnitOfWork;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestProjectN5
{
    public class UTest 
    {
        private readonly IUnitOfWork _unitOfWork;
        public UTest(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Fact]
        public async Task GetAllTest()
        {

            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            PermissionController controller = new PermissionController(mock.Object);
            //Assert
            mock.Setup(it => it.Permission.All());

            Assert.IsType<OkObjectResult>(mock);
        }
    }
}