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
    public class TrashInspectionUTest : DbTestFixture
    {
        [Test]
        public async Task TrashInspectionModel_SaveWTrue_DoesSave()
        {
            // Arrange
            Random rnd = new Random();
            TrashInspection trashInspectionModel =
                new TrashInspection
                {
                    CreatedAt = DateTime.Now,
                    Date = DateTime.Now,
                    EakCode = rnd.Next(1, 255).ToString(),
                    MustBeInspected = true,
                    Producer = Guid.NewGuid().ToString(),
                    RegistrationNumber = Guid.NewGuid().ToString(),
                    Time = DateTime.Now,
                    Transporter = Guid.NewGuid().ToString(),
                    TrashFraction = rnd.Next(1, 255).ToString(),
                    WeighingNumber = rnd.Next(1, 255).ToString()
                };
            // Act
            await trashInspectionModel.Create(DbContext);

            TrashInspection trashInspection = DbContext.TrashInspections.AsNoTracking().First();
            List<TrashInspection> trashInspectionList = DbContext.TrashInspections.AsNoTracking().ToList();
            // Assert
            Assert.That(trashInspection, Is.Not.Null);

            Assert.That(trashInspectionList.Count(), Is.EqualTo(1));

            Assert.That(trashInspection.CreatedAt.ToString(), Is.EqualTo(trashInspectionModel.CreatedAt.ToString()));
            Assert.That(trashInspection.CreatedByUserId, Is.EqualTo(trashInspectionModel.CreatedByUserId));
            Assert.That(trashInspection.Date.ToString(), Is.EqualTo(trashInspectionModel.Date.ToString()));
            Assert.That(trashInspection.EakCode, Is.EqualTo(trashInspectionModel.EakCode));
            Assert.That(trashInspection.InstallationId, Is.EqualTo(trashInspectionModel.InstallationId));
            Assert.That(trashInspection.MustBeInspected, Is.EqualTo(trashInspectionModel.MustBeInspected));
            Assert.That(trashInspection.Producer, Is.EqualTo(trashInspectionModel.Producer));
            Assert.That(trashInspection.RegistrationNumber, Is.EqualTo(trashInspectionModel.RegistrationNumber));
            Assert.That(trashInspection.Time.ToString(), Is.EqualTo(trashInspectionModel.Time.ToString()));
            Assert.That(trashInspection.Transporter, Is.EqualTo(trashInspectionModel.Transporter));
            Assert.That(trashInspection.TrashFraction, Is.EqualTo(trashInspectionModel.TrashFraction));
            Assert.That(trashInspection.WeighingNumber, Is.EqualTo(trashInspectionModel.WeighingNumber));

        }
        [Test]
        public async Task TrashInspectionModel_SaveWFalse_DoesSave()
        {
            // Arrange
            Random rnd = new Random();
            TrashInspection trashInspectionModel =
                new TrashInspection
                {
                    CreatedAt = DateTime.Now,
                    Date = DateTime.Now,
                    EakCode = rnd.Next(1, 255).ToString(),
                    MustBeInspected = false,
                    Producer = Guid.NewGuid().ToString(),
                    RegistrationNumber = Guid.NewGuid().ToString(),
                    Time = DateTime.Now,
                    Transporter = Guid.NewGuid().ToString(),
                    TrashFraction = rnd.Next(1, 255).ToString(),
                    WeighingNumber = rnd.Next(1, 255).ToString()
                };
            // Act
            await trashInspectionModel.Create(DbContext);

            TrashInspection trashInspection = DbContext.TrashInspections.AsNoTracking().First();
            List<TrashInspection> trashInspectionList = DbContext.TrashInspections.AsNoTracking().ToList();
            // Assert
            Assert.That(trashInspection, Is.Not.Null);

            Assert.That(trashInspectionList.Count(), Is.EqualTo(1));

            Assert.That(trashInspection.CreatedAt.ToString(), Is.EqualTo(trashInspectionModel.CreatedAt.ToString()));
            Assert.That(trashInspection.CreatedByUserId, Is.EqualTo(trashInspectionModel.CreatedByUserId));
            Assert.That(trashInspection.Date.ToString(), Is.EqualTo(trashInspectionModel.Date.ToString()));
            Assert.That(trashInspection.EakCode, Is.EqualTo(trashInspectionModel.EakCode));
            Assert.That(trashInspection.InstallationId, Is.EqualTo(trashInspectionModel.InstallationId));
            Assert.That(trashInspection.MustBeInspected, Is.EqualTo(trashInspectionModel.MustBeInspected));
            Assert.That(trashInspection.Producer, Is.EqualTo(trashInspectionModel.Producer));
            Assert.That(trashInspection.RegistrationNumber, Is.EqualTo(trashInspectionModel.RegistrationNumber));
            Assert.That(trashInspection.Time.ToString(), Is.EqualTo(trashInspectionModel.Time.ToString()));
            Assert.That(trashInspection.Transporter, Is.EqualTo(trashInspectionModel.Transporter));
            Assert.That(trashInspection.TrashFraction, Is.EqualTo(trashInspectionModel.TrashFraction));
            Assert.That(trashInspection.WeighingNumber, Is.EqualTo(trashInspectionModel.WeighingNumber));

        }

        [Test]
        public async Task TrashInspectionModel_UpdateWTrue_DoesUpdate()
        {
            // Arrange
            Random rnd = new Random();

            TrashInspection trashInspection =
                new TrashInspection
                {
                    CreatedAt = DateTime.Now,
                    Date = DateTime.Now,
                    EakCode = rnd.Next(1, 255).ToString(),
                    MustBeInspected = false,
                    Producer = Guid.NewGuid().ToString(),
                    RegistrationNumber = Guid.NewGuid().ToString(),
                    Time = DateTime.Now,
                    Transporter = Guid.NewGuid().ToString(),
                    TrashFraction = rnd.Next(1, 255).ToString(),
                    WeighingNumber = rnd.Next(1, 255).ToString()
                };
            await trashInspection.Create(DbContext);

            // Act
            trashInspection.EakCode = "new eak code";

            await trashInspection.Update(DbContext);

            TrashInspection dbTrashInspection = DbContext.TrashInspections.AsNoTracking().First();
            List<TrashInspection> trashInspectionList = DbContext.TrashInspections.AsNoTracking().ToList();

            // Assert
            Assert.That(dbTrashInspection, Is.Not.Null);

            Assert.That(trashInspectionList.Count(), Is.EqualTo(1));

            Assert.That(dbTrashInspection.CreatedAt.ToString(), Is.EqualTo(trashInspection.CreatedAt.ToString()));
            Assert.That(dbTrashInspection.Date.ToString(), Is.EqualTo(trashInspection.Date.ToString()));
            Assert.That(dbTrashInspection.EakCode, Is.EqualTo("new eak code"));
            Assert.That(dbTrashInspection.InstallationId, Is.EqualTo(trashInspection.InstallationId));
            Assert.That(dbTrashInspection.MustBeInspected, Is.EqualTo(trashInspection.MustBeInspected));
            Assert.That(dbTrashInspection.Producer, Is.EqualTo(trashInspection.Producer));
            Assert.That(dbTrashInspection.RegistrationNumber, Is.EqualTo(trashInspection.RegistrationNumber));
            Assert.That(dbTrashInspection.Time.ToString(), Is.EqualTo(trashInspection.Time.ToString()));
            Assert.That(dbTrashInspection.Transporter, Is.EqualTo(trashInspection.Transporter));
            Assert.That(dbTrashInspection.TrashFraction, Is.EqualTo(trashInspection.TrashFraction));
            Assert.That(dbTrashInspection.WeighingNumber, Is.EqualTo(trashInspection.WeighingNumber));
        }
        [Test]
        public async Task TrashInspectionModel_UpdateWFalse_DoesUpdate()
        {
            // Arrange
            Random rnd = new Random();

            TrashInspection trashInspection =
                new TrashInspection
                {
                    CreatedAt = DateTime.Now,
                    Date = DateTime.Now,
                    EakCode = rnd.Next(1, 255).ToString(),
                    MustBeInspected = false,
                    Producer = Guid.NewGuid().ToString(),
                    RegistrationNumber = Guid.NewGuid().ToString(),
                    Time = DateTime.Now,
                    Transporter = Guid.NewGuid().ToString(),
                    TrashFraction = rnd.Next(1, 255).ToString(),
                    WeighingNumber = rnd.Next(1, 255).ToString()
                };
            await trashInspection.Create(DbContext);

            // Act
            trashInspection.CreatedAt = trashInspection.CreatedAt;
            trashInspection.Date = trashInspection.Date;
            trashInspection.EakCode = trashInspection.EakCode;
            trashInspection.Id = trashInspection.Id;
            trashInspection.InstallationId = trashInspection.InstallationId;
            trashInspection.MustBeInspected = trashInspection.MustBeInspected;
            trashInspection.Producer = trashInspection.Producer;
            trashInspection.RegistrationNumber = trashInspection.RegistrationNumber;
            trashInspection.Time = trashInspection.Time;
            trashInspection.Transporter = trashInspection.Transporter;
            trashInspection.TrashFraction = trashInspection.TrashFraction;
            trashInspection.WeighingNumber = trashInspection.WeighingNumber;

            await  trashInspection.Update(DbContext);

            TrashInspection dbTrashInspection = DbContext.TrashInspections.AsNoTracking().First();
            List<TrashInspection> trashInspectionList = DbContext.TrashInspections.AsNoTracking().ToList();

            // Assert
            Assert.That(dbTrashInspection, Is.Not.Null);

            Assert.That(trashInspectionList.Count(), Is.EqualTo(1));

            Assert.That(dbTrashInspection.CreatedAt.ToString(), Is.EqualTo(trashInspection.CreatedAt.ToString()));
            Assert.That(dbTrashInspection.Date.ToString(), Is.EqualTo(trashInspection.Date.ToString()));
            Assert.That(dbTrashInspection.EakCode, Is.EqualTo(trashInspection.EakCode));
            Assert.That(dbTrashInspection.InstallationId, Is.EqualTo(trashInspection.InstallationId));
            Assert.That(dbTrashInspection.MustBeInspected, Is.EqualTo(trashInspection.MustBeInspected));
            Assert.That(dbTrashInspection.Producer, Is.EqualTo(trashInspection.Producer));
            Assert.That(dbTrashInspection.RegistrationNumber, Is.EqualTo(trashInspection.RegistrationNumber));
            Assert.That(dbTrashInspection.Time.ToString(), Is.EqualTo(trashInspection.Time.ToString()));
            Assert.That(dbTrashInspection.Transporter, Is.EqualTo(trashInspection.Transporter));
            Assert.That(dbTrashInspection.TrashFraction, Is.EqualTo(trashInspection.TrashFraction));
            Assert.That(dbTrashInspection.WeighingNumber, Is.EqualTo(trashInspection.WeighingNumber));
        }
        [Test]
        public async Task TrashInspectionModel_DeleteWTrue_DoesDelete()
        {
            // Arrange
            Random rnd = new Random();

            TrashInspection trashInspection =
                new TrashInspection
                {
                    CreatedAt = DateTime.Now,
                    Date = DateTime.Now,
                    EakCode = rnd.Next(1, 255).ToString(),
                    MustBeInspected = false,
                    Producer = Guid.NewGuid().ToString(),
                    RegistrationNumber = Guid.NewGuid().ToString(),
                    Time = DateTime.Now,
                    Transporter = Guid.NewGuid().ToString(),
                    TrashFraction = rnd.Next(1, 255).ToString(),
                    WeighingNumber = rnd.Next(1, 255).ToString()
                };
            await trashInspection.Create(DbContext);

            // Act
            await trashInspection.Delete(DbContext);

            TrashInspection dbTrashInspection = DbContext.TrashInspections.AsNoTracking().First();
            List<TrashInspection> trashInspectionList = DbContext.TrashInspections.AsNoTracking().ToList();

            // Assert
            Assert.That(dbTrashInspection, Is.Not.Null);

            Assert.That(trashInspectionList.Count(), Is.EqualTo(1));

            Assert.That(dbTrashInspection.CreatedAt.ToString(), Is.EqualTo(trashInspection.CreatedAt.ToString()));
            Assert.That(dbTrashInspection.Date.ToString(), Is.EqualTo(trashInspection.Date.ToString()));
            Assert.That(dbTrashInspection.EakCode, Is.EqualTo(trashInspection.EakCode));
            Assert.That(dbTrashInspection.InstallationId, Is.EqualTo(trashInspection.InstallationId));
            Assert.That(dbTrashInspection.MustBeInspected, Is.EqualTo(trashInspection.MustBeInspected));
            Assert.That(dbTrashInspection.Producer, Is.EqualTo(trashInspection.Producer));
            Assert.That(dbTrashInspection.RegistrationNumber, Is.EqualTo(trashInspection.RegistrationNumber));
            Assert.That(dbTrashInspection.Time.ToString(), Is.EqualTo(trashInspection.Time.ToString()));
            Assert.That(dbTrashInspection.Transporter, Is.EqualTo(trashInspection.Transporter));
            Assert.That(dbTrashInspection.TrashFraction, Is.EqualTo(trashInspection.TrashFraction));
            Assert.That(dbTrashInspection.WeighingNumber, Is.EqualTo(trashInspection.WeighingNumber));
            Assert.That(Constants.WorkflowStates.Removed, Is.EqualTo(trashInspection.WorkflowState));
        }
        [Test]
        public async Task TrashInspectionModel_DeleteWFalse_DoesDelete()
        {
            // Arrange
            Random rnd = new Random();

            TrashInspection trashInspection =
                new TrashInspection
                {
                    CreatedAt = DateTime.Now,
                    Date = DateTime.Now,
                    EakCode = rnd.Next(1, 255).ToString(),
                    MustBeInspected = false,
                    Producer = Guid.NewGuid().ToString(),
                    RegistrationNumber = Guid.NewGuid().ToString(),
                    Time = DateTime.Now,
                    Transporter = Guid.NewGuid().ToString(),
                    TrashFraction = rnd.Next(1, 255).ToString(),
                    WeighingNumber = rnd.Next(1, 255).ToString()
                };
            await trashInspection.Create(DbContext);

            // Act

            await trashInspection.Delete(DbContext);

            TrashInspection dbTrashInspection = DbContext.TrashInspections.AsNoTracking().First();
            List<TrashInspection> trashInspectionList = DbContext.TrashInspections.AsNoTracking().ToList();

            // Assert
            Assert.That(dbTrashInspection, Is.Not.Null);

            Assert.That(trashInspectionList.Count(), Is.EqualTo(1));

            Assert.That(dbTrashInspection.CreatedAt.ToString(), Is.EqualTo(trashInspection.CreatedAt.ToString()));
            Assert.That(dbTrashInspection.Date.ToString(), Is.EqualTo(trashInspection.Date.ToString()));
            Assert.That(dbTrashInspection.EakCode, Is.EqualTo(trashInspection.EakCode));
            Assert.That(dbTrashInspection.InstallationId, Is.EqualTo(trashInspection.InstallationId));
            Assert.That(dbTrashInspection.MustBeInspected, Is.EqualTo(trashInspection.MustBeInspected));
            Assert.That(dbTrashInspection.Producer, Is.EqualTo(trashInspection.Producer));
            Assert.That(dbTrashInspection.RegistrationNumber, Is.EqualTo(trashInspection.RegistrationNumber));
            Assert.That(dbTrashInspection.Time.ToString(), Is.EqualTo(trashInspection.Time.ToString()));
            Assert.That(dbTrashInspection.Transporter, Is.EqualTo(trashInspection.Transporter));
            Assert.That(dbTrashInspection.TrashFraction, Is.EqualTo(trashInspection.TrashFraction));
            Assert.That(dbTrashInspection.WeighingNumber, Is.EqualTo(trashInspection.WeighingNumber));
            Assert.That(Constants.WorkflowStates.Removed, Is.EqualTo(trashInspection.WorkflowState));

        }
    }
}