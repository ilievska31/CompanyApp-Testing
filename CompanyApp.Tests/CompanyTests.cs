using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;


namespace CompanyApp.Tests
{
    [TestClass]
    public class CompanyTests
    {
        [TestMethod]
        public void AddNewEmployee_WhenEmployeeIsValidAndNotPresent_ShouldAddEmployee()
        {
            var employee = new Employee();
            var dbMock = new Mock<ICompanyDatabase>();
            dbMock.Setup(db => db.EmployeeExists(employee)).Returns(false);
            var cls = new Company(dbMock.Object);

            cls.AddNewEmployee(employee);

            dbMock.Verify(db => db.AddNewEmployee(employee), Times.Once());
        }

        [TestMethod]
        public void AddNewEmployee_WhenEmployeeIsValidAndPresent_ShouldNotAddEmployee()
        {
            var employee = new Employee();
            var dbMock = new Mock<ICompanyDatabase>();
            dbMock.Setup(db => db.EmployeeExists(employee)).Returns(true);
            var cls = new Company(dbMock.Object);

            cls.AddNewEmployee(employee);

            dbMock.Verify(db => db.AddNewEmployee(employee), Times.Never());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewEmployee_WhenEmployeeNull_ShouldThrowException()
        {

            var dbMock = new Mock<ICompanyDatabase>();
            var cls = new Company(dbMock.Object);

            cls.AddNewEmployee(null);
        }

        [TestMethod]
        public void AddNewProject_WhenProjectIsValidAndNotPresent_ShouldAddProject()
        {
            var project = new Project();
            var dbMock = new Mock<ICompanyDatabase>();
            dbMock.Setup(db => db.ProjectExists(project)).Returns(false);
            var cls = new Company(dbMock.Object);

            cls.AddNewProject(project);

            dbMock.Verify(db => db.AddNewProject(project), Times.Once());
        }

        [TestMethod]        
        public void AddNewProject_WhenProjectIsValidAndPresent_ShouldNotAddProject()
        {
            var project = new Project();
            var dbMock = new Mock<ICompanyDatabase>();
            dbMock.Setup(db => db.ProjectExists(project)).Returns(true);
            var cls = new Company(dbMock.Object);

            cls.AddNewProject(project);

            dbMock.Verify(db => db.AddNewProject(project), Times.Never());
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewProject_WhenProjectNull_ShouldThrowException()
        {

            var dbMock = new Mock<ICompanyDatabase>();

            var cls = new Company(dbMock.Object);


            cls.AddNewProject(null);

        }

        [TestMethod]
        public void DeleteEmployee_WhenEmployeeIsValidAndPresent_ShouldDeleteEmployee()
        {
            var employee = new Employee();
            var dbMock = new Mock<ICompanyDatabase>();
            dbMock.Setup(db => db.EmployeeExists(employee)).Returns(true);
            var cls = new Company(dbMock.Object);

            cls.DeleteEmployee(employee);

            dbMock.Verify(db => db.DeleteEmployee(employee), Times.Once());


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteEmployee_WhenEmployeeIsValidAndNotPresent_ShouldThrowException()
        {
            var employee = new Employee();
            var dbMock = new Mock<ICompanyDatabase>();
            dbMock.Setup(db => db.EmployeeExists(employee)).Returns(false);
            var cls = new Company(dbMock.Object);

            cls.DeleteEmployee(employee);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteEmployee_WhenEmployeeIsNull_ShouldThrowException()
        {
            
            var dbMock = new Mock<ICompanyDatabase>();
            var cls = new Company(dbMock.Object);

            cls.DeleteEmployee(null);

        }

        [TestMethod]
        public void DeleteProject_WhenProjectIsValidAndPresent_ShouldDeleteProject()
        {
            var project = new Project();
            var dbMock = new Mock<ICompanyDatabase>();
            dbMock.Setup(db => db.ProjectExists(project)).Returns(true);
            var cls = new Company(dbMock.Object);

            cls.DeleteProject(project);

            dbMock.Verify(db => db.DeleteProject(project), Times.Once());


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteProject_WhenProjectIsValidAndNotPresent_ShouldThrowException()
        {
            var project = new Project();
            var dbMock = new Mock<ICompanyDatabase>();
            dbMock.Setup(db => db.ProjectExists(project)).Returns(false);
            var cls = new Company(dbMock.Object);

            cls.DeleteProject(project);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteProject_WhenProjectIsNull_ShouldThrowException()
        {

            var dbMock = new Mock<ICompanyDatabase>();
            var cls = new Company(dbMock.Object);

            cls.DeleteProject(null);

        }
                    
        [TestMethod]
        public void AssignProjectToEmployee_WhenProjectIsAlreadyAssignedToEmployee_ShouldNotAssignProject()
        {

            var employee = new Employee();
            var project = new Project();

            var dbMock = new Mock<ICompanyDatabase>();
            dbMock.Setup(db => db.EmployeeExists(employee)).Returns(true);
            dbMock.Setup(db => db.ProjectExists(project)).Returns(true);
            dbMock.Setup(db => db.EmloyeeHasProjectAssigned(project, employee)).Returns(true);
            var cls = new Company(dbMock.Object);

            cls.AssignProjectToEmployee(project, employee);
                      
            dbMock.Verify(db => db.AssignProject(employee, project), Times.Never());
        }

        [TestMethod]
        public void AssignProjectToEmployee_WhenEmployeeOrProjectAreNotPresent_ShouldThrowException()
        {

            var employee = new Employee();
            var project = new Project();

            var dbMockBothNotPresent = new Mock<ICompanyDatabase>();
            dbMockBothNotPresent.Setup(db => db.EmployeeExists(employee)).Returns(false);
            dbMockBothNotPresent.Setup(db => db.ProjectExists(project)).Returns(false);

            var dbMockNoEmployee = new Mock<ICompanyDatabase>();
            dbMockNoEmployee.Setup(db => db.EmployeeExists(employee)).Returns(false);
            dbMockNoEmployee.Setup(db => db.ProjectExists(project)).Returns(true);

            var dbMockNoProject = new Mock<ICompanyDatabase>();
            dbMockNoProject.Setup(db => db.EmployeeExists(employee)).Returns(true);
            dbMockNoProject.Setup(db => db.ProjectExists(project)).Returns(false);

            var clsBothNotPresent = new Company(dbMockBothNotPresent.Object);
            var clsNoEmployee = new Company(dbMockNoEmployee.Object);
            var clsNoProject = new Company(dbMockNoProject.Object);

            Assert.ThrowsException<ArgumentException>(() => clsBothNotPresent.AssignProjectToEmployee(project, employee));
            Assert.ThrowsException<ArgumentException>(() => clsNoEmployee.AssignProjectToEmployee(project, employee));
            Assert.ThrowsException<ArgumentException>(() => clsNoProject.AssignProjectToEmployee(project, employee));

        }

        [TestMethod]
        public void AssignProjectToEmployee_WhenProjectIsNotAssignedToEmployee_ShouldAssignProject()
        {

            var employee = new Employee();
            var project = new Project();

            var dbMock = new Mock<ICompanyDatabase>();
            dbMock.Setup(db => db.EmployeeExists(employee)).Returns(true);
            dbMock.Setup(db => db.ProjectExists(project)).Returns(true);
            dbMock.Setup(db => db.EmloyeeHasProjectAssigned(project, employee)).Returns(false);
            
            var cls = new Company(dbMock.Object);

            cls.AssignProjectToEmployee(project, employee);

            dbMock.Verify(db => db.AssignProject(employee, project), Times.Once());
        }

        [TestMethod]
        public void DeassignProjectFromEmployee_WhenProjectIsAlreadyAssignedToEmployee_ShouldDeassignProject()
        {

            var employee = new Employee();
            var project = new Project();

            var dbMock = new Mock<ICompanyDatabase>();
            dbMock.Setup(db => db.EmployeeExists(employee)).Returns(true);
            dbMock.Setup(db => db.ProjectExists(project)).Returns(true);
            dbMock.Setup(db => db.EmloyeeHasProjectAssigned(project, employee)).Returns(true);
            var cls = new Company(dbMock.Object);

            cls.DeassignProjectFromEmployee(project, employee);

            dbMock.Verify(db => db.DeassignProject(employee, project), Times.Once());
        }

        [TestMethod]
        public void DeassignProjectFromEmployee_WhenProjectIsNotAssignedToEmployee_ShouldNotAssignProject()
        {

            var employee = new Employee();
            var project = new Project();

            var dbMock = new Mock<ICompanyDatabase>();
            dbMock.Setup(db => db.EmployeeExists(employee)).Returns(true);
            dbMock.Setup(db => db.ProjectExists(project)).Returns(true);
            dbMock.Setup(db => db.EmloyeeHasProjectAssigned(project, employee)).Returns(false);

            var cls = new Company(dbMock.Object);

            cls.DeassignProjectFromEmployee(project, employee);

            dbMock.Verify(db => db.AssignProject(employee, project), Times.Never());
        }

        [TestMethod]
        public void DeassignProjectFromEmployee_WhenEmployeeOrProjectAreNotPresent_ShouldThrowException()
        {

            var employee = new Employee();
            var project = new Project();

            var dbMockBothNotPresent = new Mock<ICompanyDatabase>();
            dbMockBothNotPresent.Setup(db => db.EmployeeExists(employee)).Returns(false);
            dbMockBothNotPresent.Setup(db => db.ProjectExists(project)).Returns(false);

            var dbMockNoEmployee = new Mock<ICompanyDatabase>();
            dbMockNoEmployee.Setup(db => db.EmployeeExists(employee)).Returns(false);
            dbMockNoEmployee.Setup(db => db.ProjectExists(project)).Returns(true);

            var dbMockNoProject = new Mock<ICompanyDatabase>();
            dbMockNoProject.Setup(db => db.EmployeeExists(employee)).Returns(true);
            dbMockNoProject.Setup(db => db.ProjectExists(project)).Returns(false);

            var clsBothNotPresent = new Company(dbMockBothNotPresent.Object);
            var clsNoEmployee = new Company(dbMockNoEmployee.Object);
            var clsNoProject = new Company(dbMockNoProject.Object);

            Assert.ThrowsException<ArgumentException>(() => clsBothNotPresent.DeassignProjectFromEmployee(project, employee));
            Assert.ThrowsException<ArgumentException>(() => clsNoEmployee.DeassignProjectFromEmployee(project, employee));
            Assert.ThrowsException<ArgumentException>(() => clsNoProject.DeassignProjectFromEmployee(project, employee));

        }

    }
}
