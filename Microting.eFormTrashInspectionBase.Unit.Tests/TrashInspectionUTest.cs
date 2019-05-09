using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Microting.eFormTrashInspectionBase.Unit.Tests
{
    [TestFixture]
    public class TrashInspectionUTest : DbTestFixture
    {
        [Test]
        public void TrashInspectionModel_SaveWTrue_DoesSave()
        {
            // Arrange
            Random rnd = new Random();
            Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection trashInspectionModel = new Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection();
            trashInspectionModel.CreatedAt = DateTime.Now;
            trashInspectionModel.Date = DateTime.Now;
            trashInspectionModel.Eak_Code = rnd.Next(1, 255).ToString();
            trashInspectionModel.InstallationId = rnd.Next(1, 255);
            trashInspectionModel.MustBeInspected = true;
            trashInspectionModel.Producer = Guid.NewGuid().ToString();
            trashInspectionModel.RegistrationNumber = Guid.NewGuid().ToString();
            trashInspectionModel.Time = DateTime.Now;
            trashInspectionModel.Transporter = Guid.NewGuid().ToString();
            trashInspectionModel.TrashFraction = rnd.Next(1, 255).ToString();
            trashInspectionModel.WeighingNumber = rnd.Next(1, 255).ToString();
            // Act
            trashInspectionModel.Create(DbContext);

            Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection trashInspection = DbContext.TrashInspections.AsNoTracking().First();
            List<Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection> trashInspectionList = DbContext.TrashInspections.AsNoTracking().ToList();
            // Assert
            Assert.NotNull(trashInspection);

            Assert.AreEqual(1, trashInspectionList.Count());

            Assert.AreEqual(trashInspectionModel.CreatedAt.ToString(), trashInspection.CreatedAt.ToString());
            Assert.AreEqual(trashInspectionModel.CreatedByUserId, trashInspection.CreatedByUserId);
            Assert.AreEqual(trashInspectionModel.Date.ToString(), trashInspection.Date.ToString());
            Assert.AreEqual(trashInspectionModel.Eak_Code, trashInspection.Eak_Code);
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
        public void TrashInspectionModel_SaveWFalse_DoesSave()
        {
            // Arrange
            Random rnd = new Random();
            Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection trashInspectionModel = new Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection();
            trashInspectionModel.CreatedAt = DateTime.Now;
            trashInspectionModel.Date = DateTime.Now;
            trashInspectionModel.Eak_Code = rnd.Next(1, 255).ToString();
            trashInspectionModel.InstallationId = rnd.Next(1, 255);
            trashInspectionModel.MustBeInspected = false;
            trashInspectionModel.Producer = Guid.NewGuid().ToString();
            trashInspectionModel.RegistrationNumber = Guid.NewGuid().ToString();
            trashInspectionModel.Time = DateTime.Now;
            trashInspectionModel.Transporter = Guid.NewGuid().ToString();
            trashInspectionModel.TrashFraction = rnd.Next(1, 255).ToString();
            trashInspectionModel.WeighingNumber = rnd.Next(1, 255).ToString();
            // Act
            trashInspectionModel.Create(DbContext);

            Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection trashInspection = DbContext.TrashInspections.AsNoTracking().First();
            List<Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection> trashInspectionList = DbContext.TrashInspections.AsNoTracking().ToList();
            // Assert
            Assert.NotNull(trashInspection);

            Assert.AreEqual(1, trashInspectionList.Count());

            Assert.AreEqual(trashInspectionModel.CreatedAt.ToString(), trashInspection.CreatedAt.ToString());
            Assert.AreEqual(trashInspectionModel.CreatedByUserId, trashInspection.CreatedByUserId);
            Assert.AreEqual(trashInspectionModel.Date.ToString(), trashInspection.Date.ToString());
            Assert.AreEqual(trashInspectionModel.Eak_Code, trashInspection.Eak_Code);
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
        public void TrashInspectionModel_UpdateWTrue_DoesUpdate()
        {
            // Arrange
            Random rnd = new Random();

            Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection trashInspection = new Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection();
            trashInspection.CreatedAt = DateTime.Now;
            trashInspection.Date = DateTime.Now;
            trashInspection.Eak_Code = rnd.Next(1, 255).ToString();
            trashInspection.InstallationId = rnd.Next(1, 255);
            trashInspection.MustBeInspected = false;
            trashInspection.Producer = Guid.NewGuid().ToString();
            trashInspection.RegistrationNumber = Guid.NewGuid().ToString();
            trashInspection.Time = DateTime.Now;
            trashInspection.Transporter = Guid.NewGuid().ToString();
            trashInspection.TrashFraction = rnd.Next(1, 255).ToString();
            trashInspection.WeighingNumber = rnd.Next(1, 255).ToString();
            trashInspection.Create(DbContext);

            // Act
            trashInspection.Eak_Code = "new eak code";            

            trashInspection.Update(DbContext);

            Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection dbTrashInspection = DbContext.TrashInspections.AsNoTracking().First();
            List<Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection> trashInspectionList = DbContext.TrashInspections.AsNoTracking().ToList();

            // Assert
            Assert.NotNull(dbTrashInspection);

            Assert.AreEqual(1, trashInspectionList.Count());

            Assert.AreEqual(trashInspection.CreatedAt.ToString(), dbTrashInspection.CreatedAt.ToString());
            Assert.AreEqual(trashInspection.Date.ToString(), dbTrashInspection.Date.ToString());
            Assert.AreEqual("new eak code", dbTrashInspection.Eak_Code);
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
        public void TrashInspectionModel_UpdateWFalse_DoesUpdate()
        {
            // Arrange
            Random rnd = new Random();

            Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection trashInspection = new Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection();
            trashInspection.CreatedAt = DateTime.Now;
            trashInspection.Date = DateTime.Now;
            trashInspection.Eak_Code = rnd.Next(1, 255).ToString();
            trashInspection.InstallationId = rnd.Next(1, 255);
            trashInspection.MustBeInspected = false;
            trashInspection.Producer = Guid.NewGuid().ToString();
            trashInspection.RegistrationNumber = Guid.NewGuid().ToString();
            trashInspection.Time = DateTime.Now;
            trashInspection.Transporter = Guid.NewGuid().ToString();
            trashInspection.TrashFraction = rnd.Next(1, 255).ToString();
            trashInspection.WeighingNumber = rnd.Next(1, 255).ToString();
            trashInspection.Create(DbContext);

            // Act
            trashInspection.CreatedAt = trashInspection.CreatedAt;
            trashInspection.Date = trashInspection.Date;
            trashInspection.Eak_Code = trashInspection.Eak_Code;
            trashInspection.Id = trashInspection.Id;
            trashInspection.InstallationId = trashInspection.InstallationId;
            trashInspection.MustBeInspected = trashInspection.MustBeInspected;
            trashInspection.Producer = trashInspection.Producer;
            trashInspection.RegistrationNumber = trashInspection.RegistrationNumber;
            trashInspection.Time = trashInspection.Time;
            trashInspection.Transporter = trashInspection.Transporter;
            trashInspection.TrashFraction = trashInspection.TrashFraction;
            trashInspection.WeighingNumber = trashInspection.WeighingNumber;

            trashInspection.Update(DbContext);

            Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection dbTrashInspection = DbContext.TrashInspections.AsNoTracking().First();
            List<Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection> trashInspectionList = DbContext.TrashInspections.AsNoTracking().ToList();

            // Assert
            Assert.NotNull(dbTrashInspection);

            Assert.AreEqual(1, trashInspectionList.Count());

            Assert.AreEqual(trashInspection.CreatedAt.ToString(), dbTrashInspection.CreatedAt.ToString());
            Assert.AreEqual(trashInspection.Date.ToString(), dbTrashInspection.Date.ToString());
            Assert.AreEqual(trashInspection.Eak_Code, dbTrashInspection.Eak_Code);
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
        public void TrashInspectionModel_DeleteWTrue_DoesDelete()
        {
            // Arrange
            Random rnd = new Random();

            Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection trashInspection = new Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection();
            trashInspection.CreatedAt = DateTime.Now;
            trashInspection.Date = DateTime.Now;
            trashInspection.Eak_Code = rnd.Next(1, 255).ToString();
            trashInspection.InstallationId = rnd.Next(1, 255);
            trashInspection.MustBeInspected = false;
            trashInspection.Producer = Guid.NewGuid().ToString();
            trashInspection.RegistrationNumber = Guid.NewGuid().ToString();
            trashInspection.Time = DateTime.Now;
            trashInspection.Transporter = Guid.NewGuid().ToString();
            trashInspection.TrashFraction = rnd.Next(1, 255).ToString();
            trashInspection.WeighingNumber = rnd.Next(1, 255).ToString();
            trashInspection.Create(DbContext);

            // Act
            trashInspection.Delete(DbContext);

            Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection dbTrashInspection = DbContext.TrashInspections.AsNoTracking().First();
            List<Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection> trashInspectionList = DbContext.TrashInspections.AsNoTracking().ToList();

            // Assert
            Assert.NotNull(dbTrashInspection);

            Assert.AreEqual(1, trashInspectionList.Count());

            Assert.AreEqual(trashInspection.CreatedAt.ToString(), dbTrashInspection.CreatedAt.ToString());
            Assert.AreEqual(trashInspection.Date.ToString(), dbTrashInspection.Date.ToString());
            Assert.AreEqual(trashInspection.Eak_Code, dbTrashInspection.Eak_Code);
            Assert.AreEqual(trashInspection.InstallationId, dbTrashInspection.InstallationId);
            Assert.AreEqual(trashInspection.MustBeInspected, dbTrashInspection.MustBeInspected);
            Assert.AreEqual(trashInspection.Producer, dbTrashInspection.Producer);
            Assert.AreEqual(trashInspection.RegistrationNumber, dbTrashInspection.RegistrationNumber);
            Assert.AreEqual(trashInspection.Time.ToString(), dbTrashInspection.Time.ToString());
            Assert.AreEqual(trashInspection.Transporter, dbTrashInspection.Transporter);
            Assert.AreEqual(trashInspection.TrashFraction, dbTrashInspection.TrashFraction);
            Assert.AreEqual(trashInspection.WeighingNumber, dbTrashInspection.WeighingNumber);
            Assert.AreEqual(trashInspection.WorkflowState, eFormShared.Constants.WorkflowStates.Removed);
        }
        [Test]
        public void TrashInspectionModel_DeleteWFalse_DoesDelete()
        {
            // Arrange
            Random rnd = new Random();

            Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection trashInspection = new Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection();
            trashInspection.CreatedAt = DateTime.Now;
            trashInspection.Date = DateTime.Now;
            trashInspection.Eak_Code = rnd.Next(1, 255).ToString();
            trashInspection.InstallationId = rnd.Next(1, 255);
            trashInspection.MustBeInspected = false;
            trashInspection.Producer = Guid.NewGuid().ToString();
            trashInspection.RegistrationNumber = Guid.NewGuid().ToString();
            trashInspection.Time = DateTime.Now;
            trashInspection.Transporter = Guid.NewGuid().ToString();
            trashInspection.TrashFraction = rnd.Next(1, 255).ToString();
            trashInspection.WeighingNumber = rnd.Next(1, 255).ToString();
            trashInspection.Create(DbContext);

            // Act

            trashInspection.Delete(DbContext);

            Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection dbTrashInspection = DbContext.TrashInspections.AsNoTracking().First();
            List<Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities.TrashInspection> trashInspectionList = DbContext.TrashInspections.AsNoTracking().ToList();

            // Assert
            Assert.NotNull(dbTrashInspection);

            Assert.AreEqual(1, trashInspectionList.Count());

            Assert.AreEqual(trashInspection.CreatedAt.ToString(), dbTrashInspection.CreatedAt.ToString());
            Assert.AreEqual(trashInspection.Date.ToString(), dbTrashInspection.Date.ToString());
            Assert.AreEqual(trashInspection.Eak_Code, dbTrashInspection.Eak_Code);
            Assert.AreEqual(trashInspection.InstallationId, dbTrashInspection.InstallationId);
            Assert.AreEqual(trashInspection.MustBeInspected, dbTrashInspection.MustBeInspected);
            Assert.AreEqual(trashInspection.Producer, dbTrashInspection.Producer);
            Assert.AreEqual(trashInspection.RegistrationNumber, dbTrashInspection.RegistrationNumber);
            Assert.AreEqual(trashInspection.Time.ToString(), dbTrashInspection.Time.ToString());
            Assert.AreEqual(trashInspection.Transporter, dbTrashInspection.Transporter);
            Assert.AreEqual(trashInspection.TrashFraction, dbTrashInspection.TrashFraction);
            Assert.AreEqual(trashInspection.WeighingNumber, dbTrashInspection.WeighingNumber);
            Assert.AreEqual(trashInspection.WorkflowState, eFormShared.Constants.WorkflowStates.Removed);

        }
    }
}