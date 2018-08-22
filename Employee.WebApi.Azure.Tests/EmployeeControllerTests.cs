using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.WebApi.Azure.Controllers;
using Employee.WebApi.Azure.DataAccess;
using Employee.WebApi.Azure.Services;
using log4net;
using Moq;
using NUnit.Framework;

namespace Employee.WebApi.Azure.Tests
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeDataService> _employeeDataServiceMock;
        private Mock<ILogProvider> _logProviderMock;

        [SetUp]
        public void SetUp()
        {
            _employeeDataServiceMock = new Mock<IEmployeeDataService>(MockBehavior.Loose);
            _logProviderMock = new Mock<ILogProvider>(MockBehavior.Loose);
            _logProviderMock.Setup(lp => lp.GetLogger(It.IsAny<Type>())).Returns(new Mock<ILog>().Object);
        }

        private EmployeeController GetController()
        {
            return new EmployeeController(_logProviderMock.Object, _employeeDataServiceMock.Object);
        }

        [Test]
        public void CallToControllerShouldReachRepository()
        {
            var controller = GetController();

            var employees = controller.GetAllEmployees();

            _employeeDataServiceMock.Verify(x => x.GetEmployees(), Times.Once);
        }

        [Test]
        public void GetEmployeeByIdTest()
        {
            var controller = GetController();

            var employee = controller.GetEmployeeById(It.IsAny<int>());

            _employeeDataServiceMock.Verify(x=>x.GetEmployeeById(It.IsAny<int>()), Times.Once);

        }

    }
}
