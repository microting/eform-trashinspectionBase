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
            Assert.That(dbTransporter, Is.Not.Null);

            Assert.That(transporterList.Count, Is.EqualTo(1));
            Assert.That(transporterVersionList.Count, Is.EqualTo(1));

            Assert.That(dbTransporter.Address, Is.EqualTo(transporter.Address));
            Assert.That(dbTransporter.City, Is.EqualTo(transporter.City));
            Assert.That(dbTransporter.Description, Is.EqualTo(transporter.Description));
            Assert.That(dbTransporter.Name, Is.EqualTo(transporter.Name));
            Assert.That(dbTransporter.Phone, Is.EqualTo(transporter.Phone));
            Assert.That(dbTransporter.ContactPerson, Is.EqualTo(transporter.ContactPerson));
            Assert.That(dbTransporter.ForeignId, Is.EqualTo(transporter.ForeignId));
            Assert.That(dbTransporter.ZipCode, Is.EqualTo(transporter.ZipCode));
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
            Assert.That(dbTransporter, Is.Not.Null);

            Assert.That(transporterList.Count, Is.EqualTo(1));
            Assert.That(transporterVersionList.Count, Is.EqualTo(2));

            Assert.That(dbTransporter.Address, Is.EqualTo(newAddress));
            Assert.That(dbTransporter.City, Is.EqualTo(newCity));
            Assert.That(dbTransporter.Description, Is.EqualTo(newDescription));
            Assert.That(dbTransporter.Name, Is.EqualTo(newName));
            Assert.That(dbTransporter.Phone, Is.EqualTo(newPhone));
            Assert.That(dbTransporter.ContactPerson, Is.EqualTo(newContactPerson));
            Assert.That(dbTransporter.ForeignId, Is.EqualTo(newForeignId));
            Assert.That(dbTransporter.ZipCode, Is.EqualTo(newZipCode));
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
            Assert.That(dbTransporter, Is.Not.Null);

            Assert.That(transporterList.Count, Is.EqualTo(1));
            Assert.That(transporterVersionList.Count, Is.EqualTo(2));

            Assert.That(dbTransporter.Address, Is.EqualTo(transporter.Address));
            Assert.That(dbTransporter.City, Is.EqualTo(transporter.City));
            Assert.That(dbTransporter.Description, Is.EqualTo(transporter.Description));
            Assert.That(dbTransporter.Name, Is.EqualTo(transporter.Name));
            Assert.That(dbTransporter.Phone, Is.EqualTo(transporter.Phone));
            Assert.That(dbTransporter.ContactPerson, Is.EqualTo(transporter.ContactPerson));
            Assert.That(dbTransporter.ForeignId, Is.EqualTo(transporter.ForeignId));
            Assert.That(dbTransporter.ZipCode, Is.EqualTo(transporter.ZipCode));
            Assert.That(transporter.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
        }
    }
}