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
    public class InstallationSiteUTest : DbTestFixture
    {
        [Test]
        public void InstallationSiteModel_Save_DoesSave()
        {
            // Arrange
            Installation installation = new Installation();
            installation.CreatedAt = DateTime.Now;
            installation.Name = Guid.NewGuid().ToString();

            installation.Create(DbContext);

            Random rnd = new Random();

            InstallationSite installationSite = new InstallationSite();
            installationSite.InstallationId = installation.Id;
            installationSite.SDKSiteId = rnd.Next(1, 255);

            // Act
            installationSite.Create(DbContext);

            InstallationSite dbInstallationSite = DbContext.InstallationSites.AsNoTracking().First();
            List<InstallationSite> installationSiteList = DbContext.InstallationSites.AsNoTracking().ToList();
            List<InstallationSiteVersion> installationSiteVersions = DbContext.InstallationSiteVersions.AsNoTracking().ToList();
            // Assert
            Assert.NotNull(dbInstallationSite);

            Assert.AreEqual(1, installationSiteList.Count());
            Assert.AreEqual(1, installationSiteVersions.Count());

            Assert.AreEqual(installationSite.CreatedAt.ToString(), dbInstallationSite.CreatedAt.ToString());
            Assert.AreEqual(installationSite.InstallationId, dbInstallationSite.InstallationId);


        }

        [Test]
        public void InstalationSiteModel_Update_DoesUpdate()
        {
            // Arrange
            Installation installation = new Installation();
            installation.CreatedAt = DateTime.Now;
            installation.Name = Guid.NewGuid().ToString();

            installation.Create(DbContext);

            Random rnd = new Random();
            InstallationSite installationSite = new InstallationSite();
            installationSite.CreatedAt = DateTime.Now;
            installationSite.InstallationId = installation.Id;
            installationSite.SDKSiteId = rnd.Next(1, 255);

            installationSite.Create(DbContext);
            // Act
            
            installationSite.SDKSiteId = rnd.Next(1, 355);
            installationSite.InstallationId = installation.Id;
            installationSite.Id = installationSite.Id;

           installationSite.Update(DbContext);

            InstallationSite dbInstallationSite = DbContext.InstallationSites.AsNoTracking().First();
            List<InstallationSite> installationSiteList = DbContext.InstallationSites.AsNoTracking().ToList();
            List<InstallationSiteVersion> installationSiteVersions = DbContext.InstallationSiteVersions.AsNoTracking().ToList();

            // Assert
            Assert.NotNull(dbInstallationSite);

            Assert.AreEqual(1, installationSiteList.Count());
            Assert.AreEqual(2, installationSiteVersions.Count());

            Assert.AreEqual(installationSite.CreatedAt.ToString(), dbInstallationSite.CreatedAt.ToString());
            Assert.AreEqual(installationSite.SDKSiteId, dbInstallationSite.SDKSiteId);
            Assert.AreEqual(installationSite.InstallationId, dbInstallationSite.InstallationId);

        }

        [Test]
        public void InstallationSiteModel_Delete_DoesDelete()
        {
            // Arrange
            Installation installation = new Installation();
            installation.CreatedAt = DateTime.Now;
            installation.Name = Guid.NewGuid().ToString();

            installation.Create(DbContext);

            Random rnd = new Random();
            InstallationSite installationSite = new InstallationSite();
            installationSite.CreatedAt = DateTime.Now;
            installationSite.InstallationId = installation.Id;
            installationSite.SDKSiteId = rnd.Next(1, 255);

            installationSite.Create(DbContext);
            // Act            

            installationSite.Delete(DbContext);

            InstallationSite dbInstallationSite = DbContext.InstallationSites.AsNoTracking().First();
            List<InstallationSite> installationSiteList = DbContext.InstallationSites.AsNoTracking().ToList();
            List<InstallationSiteVersion> installationSiteVersions = DbContext.InstallationSiteVersions.AsNoTracking().ToList();

            // Assert
            Assert.NotNull(dbInstallationSite);

            Assert.AreEqual(1, installationSiteList.Count());
            Assert.AreEqual(2, installationSiteVersions.Count());

            Assert.AreEqual(installationSite.CreatedAt.ToString(), dbInstallationSite.CreatedAt.ToString());
            Assert.AreEqual(installationSite.SDKSiteId, dbInstallationSite.SDKSiteId);
            Assert.AreEqual(installationSite.InstallationId, dbInstallationSite.InstallationId);
            Assert.AreEqual(installationSite.WorkflowState, Constants.WorkflowStates.Removed);

        }

    }
}