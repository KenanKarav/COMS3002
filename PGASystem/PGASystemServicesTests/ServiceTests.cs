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

        private PGAContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<PGAContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;
            var context = new PGAContext(options);



            Programme programme1 = new Programme()
            {
                ProgrammeName = "Masters by reasearch"
            };

            Programme programme2 = new Programme()
            {
                ProgrammeName = "Masters by course work"
            };

            context.Add(programme1);
            context.Add(programme2);
            Position position1 = new Position()
            {
                Id = 1,
                PositionName = "Supervisor"
            };
            Position position2 = new Position()
            {
                Id = 2,
                PositionName = "PGO"
            };
            Position position3 = new Position()
            {
                Id = 3,
                PositionName = "PGC"
            };

            Users supervisor = new Users()
            {
                Id = 1,
                FirstName = "Fred",
                Position = position1
            };

            Application application = new Application()
            { 
                Id = 1, FirstName = "Jon", LastName = "Doe", Programme = programme1, Supervisor = supervisor
            
            };

            ApplicationFiles doc0 = new ApplicationFiles()
            {
                Application = application,
                Id = 1,
                Title = "doc0"
            };


            ApplicationFiles doc1 = new ApplicationFiles()
            {
                Application = application,
                Id = 2,
                Title = "doc1"
            };

            List<ApplicationFiles>docs = new List<ApplicationFiles>(new ApplicationFiles[] { doc0,doc1 });


            application.ApplicationFiles = docs;

            context.Add(application);



            context.SaveChanges();


            return context;
        }

        [Fact]
        public void ApplicationServiceTest()
        {
            //This tests test if GetApplication method returns valid applicant by passing applicationId
            var application = new ApplicationService(GetContextWithData());
            var result = application.GetApplication(1).FirstName;
            Assert.Equal("Jon", result);


            //This tests test if GetAllFiles method returns valid files is returned by passing applicationId
            var result2 = application.GetAllFiles(1).ToList();

            for (int i = 0; i < result2.Count; i++)
            {
      
                Assert.Equal("doc"+i, result2[i].Title);
            }
       


        }





    }
}
