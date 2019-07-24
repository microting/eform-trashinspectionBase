using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace Microting.eFormTrashInspectionBase.Unit.Tests
{
    [TestFixture]
    public class InstallationUTest : DbTestFixture
    {
        [Test]
        public void  InstallationModel_Save_DoesSave()
        {
            // Arrange
            Random rnd = new Random();
            Installation installation = new Installation();
            installation.CreatedAt = DateTime.Now;
            installation.Name = Guid.NewGuid().ToString();
            
            // Act
            installation.Create(DbContext);

            Installation dbInstallation = DbContext.Installations.AsNoTracking().First();
            List<Installation> installationList = DbContext.Installations.AsNoTracking().ToList();
            // Assert
            Assert.NotNull(dbInstallation);

            Assert.AreEqual(1, installationList.Count());

            Assert.AreEqual(installation.CreatedAt.ToString(), dbInstallation.CreatedAt.ToString());
            Assert.AreEqual(installation.Name, dbInstallation.Name);
           

        }
        
        [Test]
        public void  InstalationModel_Update_DoesUpdate()
        {
            // Arrange
            Random rnd = new Random();
            Installation installation = new Installation();
            installation.CreatedAt = DateTime.Now;
            installation.Name = Guid.NewGuid().ToString();
            
            installation.Create(DbContext);

            // Act
            installation.Name = "new name";

            installation.Update(DbContext);

            Installation dbInstallation = DbContext.Installations.AsNoTracking().First();
            List<Installation> installationList = DbContext.Installations.AsNoTracking().ToList();
            List<InstallationVersion> installationVersionList = DbContext.InstallationVersions.AsNoTracking().ToList();
            // Assert
            Assert.NotNull(dbInstallation);

            Assert.AreEqual(1, installationList.Count());
            Assert.AreEqual(2, installationVersionList.Count());

            Assert.AreEqual(installation.CreatedAt.ToString(), dbInstallation.CreatedAt.ToString());
            Assert.AreEqual(installation.Name, dbInstallation.Name);
            Assert.AreEqual(installation.Id, dbInstallation.Id);
           
        }
        
        [Test]
        public void  InstallationModel_Delete_DoesDelete()
        {
            // Arrange
            Random rnd = new Random();
            Installation installation = new Installation();
            installation.CreatedAt = DateTime.Now;
            installation.Name = Guid.NewGuid().ToString();
            
            installation.Create(DbContext);

            // Act

            installation.Delete(DbContext);

            Installation dbInstallation = DbContext.Installations.AsNoTracking().First();
            List<Installation> installationList = DbContext.Installations.AsNoTracking().ToList();
            List<InstallationVersion> installationVersionList = DbContext.InstallationVersions.AsNoTracking().ToList();
            // Assert
            Assert.NotNull(dbInstallation);

            Assert.AreEqual(1, installationList.Count());
            Assert.AreEqual(2, installationVersionList.Count());

            Assert.AreEqual(installation.CreatedAt.ToString(), dbInstallation.CreatedAt.ToString());
            Assert.AreEqual(installation.Name, dbInstallation.Name);
            Assert.AreEqual(installation.Id, dbInstallation.Id);
            Assert.AreEqual(installation.WorkflowState, Constants.WorkflowStates.Removed);

        }

    }
}