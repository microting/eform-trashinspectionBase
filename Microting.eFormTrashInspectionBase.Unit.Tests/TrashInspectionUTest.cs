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
                    InstallationId = rnd.Next(1, 255),
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
            Assert.NotNull(trashInspection);

            Assert.AreEqual(1, trashInspectionList.Count());

            Assert.AreEqual(trashInspectionModel.CreatedAt.ToString(), trashInspection.CreatedAt.ToString());
            Assert.AreEqual(trashInspectionModel.CreatedByUserId, trashInspection.CreatedByUserId);
            Assert.AreEqual(trashInspectionModel.Date.ToString(), trashInspection.Date.ToString());
            Assert.AreEqual(trashInspectionModel.EakCode, trashInspection.EakCode);
            Assert.AreEqual(trashInspectionModel.InstallationId, trashInspection.InstallationId);
            Assert.AreEqual(trashInspectionModel.MustBeInspected, trashInspection.MustBeInspected);
            Assert.AreEqual(trashInspectionModel.Producer, trashInspection.Producer);
            Assert.AreEqual(trashInspectionModel.RegistrationNumber, trashInspection.RegistrationNumber);
            Assert.AreEqual(trashInspectionModel.Time.ToString(), trashInspection.Time.ToString());
            Assert.AreEqual(trashInspectionModel.Transporter, trashInspection.Transporter);
            Assert.AreEqual(trashInspectionModel.TrashFraction, trashInspection.TrashFraction);
            Assert.AreEqual(trashInspectionModel.WeighingNumber, trashInspection.WeighingNumber);

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
                    InstallationId = rnd.Next(1, 255),
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
            Assert.NotNull(trashInspection);

            Assert.AreEqual(1, trashInspectionList.Count());

            Assert.AreEqual(trashInspectionModel.CreatedAt.ToString(), trashInspection.CreatedAt.ToString());
            Assert.AreEqual(trashInspectionModel.CreatedByUserId, trashInspection.CreatedByUserId);
            Assert.AreEqual(trashInspectionModel.Date.ToString(), trashInspection.Date.ToString());
            Assert.AreEqual(trashInspectionModel.EakCode, trashInspection.EakCode);
            Assert.AreEqual(trashInspectionModel.InstallationId, trashInspection.InstallationId);
            Assert.AreEqual(trashInspectionModel.MustBeInspected, trashInspection.MustBeInspected);
            Assert.AreEqual(trashInspectionModel.Producer, trashInspection.Producer);
            Assert.AreEqual(trashInspectionModel.RegistrationNumber, trashInspection.RegistrationNumber);
            Assert.AreEqual(trashInspectionModel.Time.ToString(), trashInspection.Time.ToString());
            Assert.AreEqual(trashInspectionModel.Transporter, trashInspection.Transporter);
            Assert.AreEqual(trashInspectionModel.TrashFraction, trashInspection.TrashFraction);
            Assert.AreEqual(trashInspectionModel.WeighingNumber, trashInspection.WeighingNumber);

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
                    InstallationId = rnd.Next(1, 255),
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
            Assert.NotNull(dbTrashInspection);

            Assert.AreEqual(1, trashInspectionList.Count());

            Assert.AreEqual(trashInspection.CreatedAt.ToString(), dbTrashInspection.CreatedAt.ToString());
            Assert.AreEqual(trashInspection.Date.ToString(), dbTrashInspection.Date.ToString());
            Assert.AreEqual("new eak code", dbTrashInspection.EakCode);
            Assert.AreEqual(trashInspection.InstallationId, dbTrashInspection.InstallationId);
            Assert.AreEqual(trashInspection.MustBeInspected, dbTrashInspection.MustBeInspected);
            Assert.AreEqual(trashInspection.Producer, dbTrashInspection.Producer);
            Assert.AreEqual(trashInspection.RegistrationNumber, dbTrashInspection.RegistrationNumber);
            Assert.AreEqual(trashInspection.Time.ToString(), dbTrashInspection.Time.ToString());
            Assert.AreEqual(trashInspection.Transporter, dbTrashInspection.Transporter);
            Assert.AreEqual(trashInspection.TrashFraction, dbTrashInspection.TrashFraction);
            Assert.AreEqual(trashInspection.WeighingNumber, dbTrashInspection.WeighingNumber);
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
                    InstallationId = rnd.Next(1, 255),
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
            Assert.NotNull(dbTrashInspection);

            Assert.AreEqual(1, trashInspectionList.Count());

            Assert.AreEqual(trashInspection.CreatedAt.ToString(), dbTrashInspection.CreatedAt.ToString());
            Assert.AreEqual(trashInspection.Date.ToString(), dbTrashInspection.Date.ToString());
            Assert.AreEqual(trashInspection.EakCode, dbTrashInspection.EakCode);
            Assert.AreEqual(trashInspection.InstallationId, dbTrashInspection.InstallationId);
            Assert.AreEqual(trashInspection.MustBeInspected, dbTrashInspection.MustBeInspected);
            Assert.AreEqual(trashInspection.Producer, dbTrashInspection.Producer);
            Assert.AreEqual(trashInspection.RegistrationNumber, dbTrashInspection.RegistrationNumber);
            Assert.AreEqual(trashInspection.Time.ToString(), dbTrashInspection.Time.ToString());
            Assert.AreEqual(trashInspection.Transporter, dbTrashInspection.Transporter);
            Assert.AreEqual(trashInspection.TrashFraction, dbTrashInspection.TrashFraction);
            Assert.AreEqual(trashInspection.WeighingNumber, dbTrashInspection.WeighingNumber);
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
                    InstallationId = rnd.Next(1, 255),
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
            Assert.NotNull(dbTrashInspection);

            Assert.AreEqual(1, trashInspectionList.Count());

            Assert.AreEqual(trashInspection.CreatedAt.ToString(), dbTrashInspection.CreatedAt.ToString());
            Assert.AreEqual(trashInspection.Date.ToString(), dbTrashInspection.Date.ToString());
            Assert.AreEqual(trashInspection.EakCode, dbTrashInspection.EakCode);
            Assert.AreEqual(trashInspection.InstallationId, dbTrashInspection.InstallationId);
            Assert.AreEqual(trashInspection.MustBeInspected, dbTrashInspection.MustBeInspected);
            Assert.AreEqual(trashInspection.Producer, dbTrashInspection.Producer);
            Assert.AreEqual(trashInspection.RegistrationNumber, dbTrashInspection.RegistrationNumber);
            Assert.AreEqual(trashInspection.Time.ToString(), dbTrashInspection.Time.ToString());
            Assert.AreEqual(trashInspection.Transporter, dbTrashInspection.Transporter);
            Assert.AreEqual(trashInspection.TrashFraction, dbTrashInspection.TrashFraction);
            Assert.AreEqual(trashInspection.WeighingNumber, dbTrashInspection.WeighingNumber);
            Assert.AreEqual(trashInspection.WorkflowState, Constants.WorkflowStates.Removed);
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
                    InstallationId = rnd.Next(1, 255),
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
            Assert.NotNull(dbTrashInspection);

            Assert.AreEqual(1, trashInspectionList.Count());

            Assert.AreEqual(trashInspection.CreatedAt.ToString(), dbTrashInspection.CreatedAt.ToString());
            Assert.AreEqual(trashInspection.Date.ToString(), dbTrashInspection.Date.ToString());
            Assert.AreEqual(trashInspection.EakCode, dbTrashInspection.EakCode);
            Assert.AreEqual(trashInspection.InstallationId, dbTrashInspection.InstallationId);
            Assert.AreEqual(trashInspection.MustBeInspected, dbTrashInspection.MustBeInspected);
            Assert.AreEqual(trashInspection.Producer, dbTrashInspection.Producer);
            Assert.AreEqual(trashInspection.RegistrationNumber, dbTrashInspection.RegistrationNumber);
            Assert.AreEqual(trashInspection.Time.ToString(), dbTrashInspection.Time.ToString());
            Assert.AreEqual(trashInspection.Transporter, dbTrashInspection.Transporter);
            Assert.AreEqual(trashInspection.TrashFraction, dbTrashInspection.TrashFraction);
            Assert.AreEqual(trashInspection.WeighingNumber, dbTrashInspection.WeighingNumber);
            Assert.AreEqual(trashInspection.WorkflowState, Constants.WorkflowStates.Removed);

        }
    }
}