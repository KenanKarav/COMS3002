using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PGASystemData;
using PGASystemData.Models;
using PGASystemServices;
using Xunit;

namespace PGASystemServicesTests
{
    public class ServicesTest
    {
        /* Create a dummy application service*/

        ApplicationService _application = new ApplicationService(GetContextWithData());
        /* Create a dummy user service*/

        UserService _user = new UserService(GetContextWithData());

        private static PGAContext GetContextWithData()
        {
            /* Initialize an in-memory Db context, we are not using the context linked to the
             * SQL server as that falls under integration tests */

            var options = new DbContextOptionsBuilder<PGAContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;
            var context = new PGAContext(options);


            /* Add seed data to in-memory context */
            Programme programme1 = new Programme() { Id = 1, ProgrammeName = "Masters by reasearch" };
            Programme programme2 = new Programme() { Id = 2, ProgrammeName = "Masters by course work" };
            context.Add(programme1);
            context.Add(programme2);

            Position position1 = new Position() { Id = 1, PositionName = "Supervisor" };
            Position position2 = new Position() { Id = 2, PositionName = "PGO" };
            Position position3 = new Position() { Id = 3, PositionName = "PGC" };
            context.Add(position1);
            context.Add(position2);
            context.Add(position3);

            Users supervisor = new Users() { Id = 1, FirstName = "Fred", Position = position1 };
            context.Add(supervisor);


            Application application = new Application()
            {
                Id = 1,
                FirstName = "Jon",
                LastName = "Doe",
                Programme = programme1,
                Supervisor = supervisor
            };
            context.Add(application);

            ApplicationFiles file1 = new ApplicationFiles() { Application = application, Id = 1, Title = "FirstDoc" };
            ApplicationFiles file2 = new ApplicationFiles() { Application = application, Id = 2, Title = "SecondDoc" };
            context.Add(file1);
            context.Add(file2);


            List<ApplicationFiles> docs = new List<ApplicationFiles>(new ApplicationFiles[] { file1, file2 });
            application.ApplicationFiles = docs;

            context.SaveChanges();


            return context;
        }

        /* Tests the GetApplication Application service with 2 test cases */
        [Fact]
        public void TestGetApplication()
        {


            /* Test if GetApplication method returns valid applicant by passing applicationId */
            var resultFirstName = _application.GetApplication(1).FirstName;
            Assert.Equal("Jon", resultFirstName);


            /* Test that GetApplication throws a valid exception 
             * with a description if an invalid (negative id or non-existent applicationId) 
             * applicationId is accessed*/

            try
            {
                _application.GetApplication(3);
            }
            catch (Exception e)
            {
                Assert.Equal("Application does not exist", e.Message);
            }




        }

        /* Tests the GetAllFiles in Application service with 3 test cases*/
        [Fact]
        public void TestGetAllFiles()
        {
            /* Test if correct number of files is returned for valid application id */
            var files = _application.GetAllFiles(1);
            int countFiles = files.Count();
            Assert.Equal(2, countFiles);

            /* Test if correct file data is returned for valid application id */
            Assert.Equal("FirstDoc", files.ElementAt(0).Title);
            Assert.Equal("SecondDoc", files.ElementAt(1).Title);

            /* Test for valid exception if application does not exist */
            try
            {
                _application.GetAllFiles(3);
            }
            catch (Exception e)
            {
                Assert.Equal("Application does not exist", e.Message);
            }

        }

        /* Tests  AddApplication() in Application service with 1 test case */
        [Fact]
        public void TestAddApplication()
        {
            /* Tests if application is added to context */
            Application application = new Application()
            {
                Id = 2,
                FirstName = "George",
                LastName = "Bikles",
            };

            _application.Add(application);
            var getApplication = _application.GetApplication(2);
            Assert.Equal(2, getApplication.Id);


        }

        /* Test GetSupervisorbyId in User service method with 2 test cases */
        [Fact]
        public void TestGetSupervisorById()
        {
            /* Test get a valid supervisor */

            var user = _user.GetSupervisorById(1);
            Assert.NotNull(user);
            Assert.Equal("Fred", user.FirstName);

            /* Test an invalid supervisor */

            try
            {
                _user.GetSupervisorById(10);
            }
            catch (Exception e)
            {
                Assert.Equal("Supervisor does not exist", e.Message);
            }
        }


    }
}
