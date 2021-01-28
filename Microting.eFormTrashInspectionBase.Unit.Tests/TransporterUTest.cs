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
    public class TransporterUTest : DbTestFixture
    {
        [Test]
        public async Task Transporter_Save_DoesSave()
        {
            //Arrange
            Transporter transporter = new Transporter
            {
                Address = Guid.NewGuid().ToString(),
                City = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString(),
                ContactPerson = Guid.NewGuid().ToString(),
                ForeignId = Guid.NewGuid().ToString(),
                ZipCode = Guid.NewGuid().ToString()
            };


            //Act
            await transporter.Create(DbContext);

            Transporter dbTransporter = DbContext.Transporters.AsNoTracking().First();
            List<Transporter> transporterList = DbContext.Transporters.AsNoTracking().ToList();
            List<TransporterVersion> transporterVersionList = DbContext.TransporterVersions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbTransporter);

            Assert.AreEqual(1, transporterList.Count);
            Assert.AreEqual(1, transporterVersionList.Count);

            Assert.AreEqual(transporter.Address, dbTransporter.Address);
            Assert.AreEqual(transporter.City, dbTransporter.City);
            Assert.AreEqual(transporter.Description, dbTransporter.Description);
            Assert.AreEqual(transporter.Name, dbTransporter.Name);
            Assert.AreEqual(transporter.Phone, dbTransporter.Phone);
            Assert.AreEqual(transporter.ContactPerson, dbTransporter.ContactPerson);
            Assert.AreEqual(transporter.ForeignId, dbTransporter.ForeignId);
            Assert.AreEqual(transporter.ZipCode, dbTransporter.ZipCode);
        }
        [Test]
        public async Task Transporter_Update_DoesUpdate()
        {
            //Arrange
            Transporter transporter = new Transporter
            {
                Address = Guid.NewGuid().ToString(),
                City = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString(),
                ContactPerson = Guid.NewGuid().ToString(),
                ForeignId = Guid.NewGuid().ToString(),
                ZipCode = Guid.NewGuid().ToString()
            };

            await transporter.Create(DbContext);

            string newAddress = Guid.NewGuid().ToString();
            string newCity = Guid.NewGuid().ToString();
            string newDescription = Guid.NewGuid().ToString();
            string newName = Guid.NewGuid().ToString();
            string newPhone = Guid.NewGuid().ToString();
            string newContactPerson = Guid.NewGuid().ToString();
            string newForeignId = Guid.NewGuid().ToString();
            string newZipCode = Guid.NewGuid().ToString();

            transporter.Address = newAddress;
            transporter.City = newCity;
            transporter.Description = newDescription;
            transporter.Name = newName;
            transporter.Phone = newPhone;
            transporter.ContactPerson = newContactPerson;
            transporter.ForeignId = newForeignId;
            transporter.ZipCode = newZipCode;
            //Act
            await transporter.Update(DbContext);

            Transporter dbTransporter = DbContext.Transporters.AsNoTracking().First();
            List<Transporter> transporterList = DbContext.Transporters.AsNoTracking().ToList();
            List<TransporterVersion> transporterVersionList = DbContext.TransporterVersions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbTransporter);

            Assert.AreEqual(1, transporterList.Count);
            Assert.AreEqual(2, transporterVersionList.Count);

            Assert.AreEqual(newAddress, dbTransporter.Address);
            Assert.AreEqual(newCity, dbTransporter.City);
            Assert.AreEqual(newDescription, dbTransporter.Description);
            Assert.AreEqual(newName, dbTransporter.Name);
            Assert.AreEqual(newPhone, dbTransporter.Phone);
            Assert.AreEqual(newContactPerson, dbTransporter.ContactPerson);
            Assert.AreEqual(newForeignId, dbTransporter.ForeignId);
            Assert.AreEqual(newZipCode, dbTransporter.ZipCode);
        }
        [Test]
        public async Task Transporter_Delete_DoesDelete()
        {
            //Arrange
            Transporter transporter = new Transporter
            {
                Address = Guid.NewGuid().ToString(),
                City = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString(),
                ContactPerson = Guid.NewGuid().ToString(),
                ForeignId = Guid.NewGuid().ToString(),
                ZipCode = Guid.NewGuid().ToString()
            };

            await transporter.Create(DbContext);

            //Act
            await transporter.Delete(DbContext);

            Transporter dbTransporter = DbContext.Transporters.AsNoTracking().First();
            List<Transporter> transporterList = DbContext.Transporters.AsNoTracking().ToList();
            List<TransporterVersion> transporterVersionList = DbContext.TransporterVersions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbTransporter);

            Assert.AreEqual(1, transporterList.Count);
            Assert.AreEqual(2, transporterVersionList.Count);

            Assert.AreEqual(transporter.Address, dbTransporter.Address);
            Assert.AreEqual(transporter.City, dbTransporter.City);
            Assert.AreEqual(transporter.Description, dbTransporter.Description);
            Assert.AreEqual(transporter.Name, dbTransporter.Name);
            Assert.AreEqual(transporter.Phone, dbTransporter.Phone);
            Assert.AreEqual(transporter.ContactPerson, dbTransporter.ContactPerson);
            Assert.AreEqual(transporter.ForeignId, dbTransporter.ForeignId);
            Assert.AreEqual(transporter.ZipCode, dbTransporter.ZipCode);
            Assert.AreEqual(Constants.WorkflowStates.Removed, transporter.WorkflowState);
        }
    }
}