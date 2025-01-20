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
    public class InstallationUTest : DbTestFixture
    {
        [Test]
        public async Task  InstallationModel_Save_DoesSave()
        {
            // Arrange
            Random rnd = new Random();
            Installation installation = new Installation {CreatedAt = DateTime.Now, Name = Guid.NewGuid().ToString()};

            // Act
            await installation.Create(DbContext);

            Installation dbInstallation = DbContext.Installations.AsNoTracking().First();
            List<Installation> installationList = DbContext.Installations.AsNoTracking().ToList();
            // Assert
            Assert.That(dbInstallation, Is.Not.Null);

            Assert.That(installationList.Count(), Is.EqualTo(1));

            Assert.That(dbInstallation.CreatedAt.ToString(), Is.EqualTo(installation.CreatedAt.ToString()));
            Assert.That(dbInstallation.Name, Is.EqualTo(installation.Name));


        }

        [Test]
        public async Task  InstalationModel_Update_DoesUpdate()
        {
            // Arrange
            Random rnd = new Random();
            Installation installation = new Installation {CreatedAt = DateTime.Now, Name = Guid.NewGuid().ToString()};

            await installation.Create(DbContext);

            // Act
            installation.Name = "new name";

            await installation.Update(DbContext);

            Installation dbInstallation = DbContext.Installations.AsNoTracking().First();
            List<Installation> installationList = DbContext.Installations.AsNoTracking().ToList();
            List<InstallationVersion> installationVersionList = DbContext.InstallationVersions.AsNoTracking().ToList();
            // Assert
            Assert.That(dbInstallation, Is.Not.Null);

            Assert.That(installationList.Count(), Is.EqualTo(1));
            Assert.That(installationVersionList.Count(), Is.EqualTo(2));

            Assert.That(dbInstallation.CreatedAt.ToString(), Is.EqualTo(installation.CreatedAt.ToString()));
            Assert.That(dbInstallation.Name, Is.EqualTo(installation.Name));
            Assert.That(dbInstallation.Id, Is.EqualTo(installation.Id));

        }

        [Test]
        public async Task  InstallationModel_Delete_DoesDelete()
        {
            // Arrange
            Random rnd = new Random();
            Installation installation = new Installation {CreatedAt = DateTime.Now, Name = Guid.NewGuid().ToString()};

            await installation.Create(DbContext);

            // Act

            await installation.Delete(DbContext);

            Installation dbInstallation = DbContext.Installations.AsNoTracking().First();
            List<Installation> installationList = DbContext.Installations.AsNoTracking().ToList();
            List<InstallationVersion> installationVersionList = DbContext.InstallationVersions.AsNoTracking().ToList();
            // Assert
            Assert.That(dbInstallation, Is.Not.Null);

            Assert.That(installationList.Count(), Is.EqualTo(1));
            Assert.That(installationVersionList.Count(), Is.EqualTo(2));

            Assert.That(dbInstallation.CreatedAt.ToString(), Is.EqualTo(installation.CreatedAt.ToString()));
            Assert.That(dbInstallation.Name, Is.EqualTo(installation.Name));
            Assert.That(dbInstallation.Id, Is.EqualTo(installation.Id));
            Assert.That(Constants.WorkflowStates.Removed, Is.EqualTo(installation.WorkflowState));

        }

    }
}