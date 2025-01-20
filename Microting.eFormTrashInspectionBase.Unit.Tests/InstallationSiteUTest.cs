using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task InstallationSiteModel_Save_DoesSave()
        {
            // Arrange
            Installation installation = new Installation {CreatedAt = DateTime.Now, Name = Guid.NewGuid().ToString()};

            await installation.Create(DbContext);

            Random rnd = new Random();

            InstallationSite installationSite = new InstallationSite
            {
                InstallationId = installation.Id, SDKSiteId = rnd.Next(1, 255)
            };

            // Act
            await installationSite.Create(DbContext);

            InstallationSite dbInstallationSite = DbContext.InstallationSites.AsNoTracking().First();
            List<InstallationSite> installationSiteList = DbContext.InstallationSites.AsNoTracking().ToList();
            List<InstallationSiteVersion> installationSiteVersions = DbContext.InstallationSiteVersions.AsNoTracking().ToList();
            // Assert
            Assert.That(dbInstallationSite, Is.Not.Null);

            Assert.That(installationSiteList.Count(), Is.EqualTo(1));
            Assert.That(installationSiteVersions.Count(), Is.EqualTo(1));

            Assert.That(dbInstallationSite.CreatedAt.ToString(), Is.EqualTo(installationSite.CreatedAt.ToString()));
            Assert.That(dbInstallationSite.InstallationId, Is.EqualTo(installationSite.InstallationId));


        }

        [Test]
        public async Task InstalationSiteModel_Update_DoesUpdate()
        {
            // Arrange
            Installation installation = new Installation {CreatedAt = DateTime.Now, Name = Guid.NewGuid().ToString()};

            await installation.Create(DbContext);

            Random rnd = new Random();
            InstallationSite installationSite = new InstallationSite
            {
                CreatedAt = DateTime.Now, InstallationId = installation.Id, SDKSiteId = rnd.Next(1, 255)
            };

            await installationSite.Create(DbContext);
            // Act

            installationSite.SDKSiteId = rnd.Next(1, 355);
            installationSite.InstallationId = installation.Id;
            installationSite.Id = installationSite.Id;

            await installationSite.Update(DbContext);

            InstallationSite dbInstallationSite = DbContext.InstallationSites.AsNoTracking().First();
            List<InstallationSite> installationSiteList = DbContext.InstallationSites.AsNoTracking().ToList();
            List<InstallationSiteVersion> installationSiteVersions = DbContext.InstallationSiteVersions.AsNoTracking().ToList();

            // Assert
            Assert.That(dbInstallationSite, Is.Not.Null);

            Assert.That(installationSiteList.Count(), Is.EqualTo(1));
            Assert.That(installationSiteVersions.Count(), Is.EqualTo(2));

            Assert.That(dbInstallationSite.CreatedAt.ToString(), Is.EqualTo(installationSite.CreatedAt.ToString()));
            Assert.That(dbInstallationSite.SDKSiteId, Is.EqualTo(installationSite.SDKSiteId));
            Assert.That(dbInstallationSite.InstallationId, Is.EqualTo(installationSite.InstallationId));

        }

        [Test]
        public async Task InstallationSiteModel_Delete_DoesDelete()
        {
            // Arrange
            Installation installation = new Installation {CreatedAt = DateTime.Now, Name = Guid.NewGuid().ToString()};

            await installation.Create(DbContext);

            Random rnd = new Random();
            InstallationSite installationSite = new InstallationSite
            {
                CreatedAt = DateTime.Now, InstallationId = installation.Id, SDKSiteId = rnd.Next(1, 255)
            };

            await installationSite.Create(DbContext);
            // Act

            await installationSite.Delete(DbContext);

            InstallationSite dbInstallationSite = DbContext.InstallationSites.AsNoTracking().First();
            List<InstallationSite> installationSiteList = DbContext.InstallationSites.AsNoTracking().ToList();
            List<InstallationSiteVersion> installationSiteVersions = DbContext.InstallationSiteVersions.AsNoTracking().ToList();

            // Assert
            Assert.That(dbInstallationSite, Is.Not.Null);

            Assert.That(installationSiteList.Count(), Is.EqualTo(1));
            Assert.That(installationSiteVersions.Count(), Is.EqualTo(2));

            Assert.That(dbInstallationSite.CreatedAt.ToString(), Is.EqualTo(installationSite.CreatedAt.ToString()));
            Assert.That(dbInstallationSite.SDKSiteId, Is.EqualTo(installationSite.SDKSiteId));
            Assert.That(dbInstallationSite.InstallationId, Is.EqualTo(installationSite.InstallationId));
            Assert.That(Constants.WorkflowStates.Removed, Is.EqualTo(installationSite.WorkflowState));

        }

    }
}