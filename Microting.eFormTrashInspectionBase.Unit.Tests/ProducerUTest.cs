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
    public class ProducerUTest : DbTestFixture
    {
        [Test]
        public async Task Producer_Save_DoesSave()
        {
            //Arrange
            Producer producer = new Producer();

            producer.Address = Guid.NewGuid().ToString();
            producer.City = Guid.NewGuid().ToString();
            producer.Description = Guid.NewGuid().ToString();
            producer.Name = Guid.NewGuid().ToString();
            producer.Phone = Guid.NewGuid().ToString();
            producer.ContactPerson = Guid.NewGuid().ToString();
            producer.ForeignId = Guid.NewGuid().ToString();
            producer.ZipCode = Guid.NewGuid().ToString();

            //Act
            await producer.Create(DbContext);

            Producer dbProducer = DbContext.Producers.AsNoTracking().First();
            List<Producer> producerList = DbContext.Producers.AsNoTracking().ToList();
            List<ProducerVersion> producerVersionList = DbContext.ProducerVersions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbProducer);
            
            Assert.AreEqual(1, producerList.Count);
            Assert.AreEqual(1, producerVersionList.Count);
            
            Assert.AreEqual(producer.Address, dbProducer.Address);
            Assert.AreEqual(producer.City, dbProducer.City);
            Assert.AreEqual(producer.Description, dbProducer.Description);
            Assert.AreEqual(producer.Name, dbProducer.Name);
            Assert.AreEqual(producer.Phone, dbProducer.Phone);
            Assert.AreEqual(producer.ContactPerson, dbProducer.ContactPerson);
            Assert.AreEqual(producer.ForeignId, dbProducer.ForeignId);
            Assert.AreEqual(producer.ZipCode, dbProducer.ZipCode);
        }
        [Test]
        public async Task Producer_Update_DoesUpdate()
        {
            //Arrange
            Producer producer = new Producer();

            producer.Address = Guid.NewGuid().ToString();
            producer.City = Guid.NewGuid().ToString();
            producer.Description = Guid.NewGuid().ToString();
            producer.Name = Guid.NewGuid().ToString();
            producer.Phone = Guid.NewGuid().ToString();
            producer.ContactPerson = Guid.NewGuid().ToString();
            producer.ForeignId = Guid.NewGuid().ToString();
            producer.ZipCode = Guid.NewGuid().ToString();
            await producer.Create(DbContext);

            string newAddress = Guid.NewGuid().ToString();
            string newCity = Guid.NewGuid().ToString();
            string newDescription = Guid.NewGuid().ToString();
            string newName = Guid.NewGuid().ToString();
            string newPhone = Guid.NewGuid().ToString();
            string newContactPerson = Guid.NewGuid().ToString();
            string newForeignId = Guid.NewGuid().ToString();
            string newZipCode = Guid.NewGuid().ToString();

            producer.Address = newAddress;
            producer.City = newCity;
            producer.Description = newDescription;
            producer.Name = newName;
            producer.Phone = newPhone;
            producer.ContactPerson = newContactPerson;
            producer.ForeignId = newForeignId;
            producer.ZipCode = newZipCode;
            //Act
            await producer.Update(DbContext);
            
            Producer dbProducer = DbContext.Producers.AsNoTracking().First();
            List<Producer> producerList = DbContext.Producers.AsNoTracking().ToList();
            List<ProducerVersion> producerVersionList = DbContext.ProducerVersions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbProducer);
            
            Assert.AreEqual(1, producerList.Count);
            Assert.AreEqual(2, producerVersionList.Count);
            
            Assert.AreEqual(newAddress, dbProducer.Address);
            Assert.AreEqual(newCity, dbProducer.City);
            Assert.AreEqual(newDescription, dbProducer.Description);
            Assert.AreEqual(newName, dbProducer.Name);
            Assert.AreEqual(newPhone, dbProducer.Phone);
            Assert.AreEqual(newContactPerson, dbProducer.ContactPerson);
            Assert.AreEqual(newForeignId, dbProducer.ForeignId);
            Assert.AreEqual(newZipCode, dbProducer.ZipCode);
        }
        [Test]
        public async Task Producer_Delete_DoesDelete()
        {
            //Arrange
            Producer producer = new Producer();

            producer.Address = Guid.NewGuid().ToString();
            producer.City = Guid.NewGuid().ToString();
            producer.Description = Guid.NewGuid().ToString();
            producer.Name = Guid.NewGuid().ToString();
            producer.Phone = Guid.NewGuid().ToString();
            producer.ContactPerson = Guid.NewGuid().ToString();
            producer.ForeignId = Guid.NewGuid().ToString();
            producer.ZipCode = Guid.NewGuid().ToString();
            await producer.Create(DbContext);

            //Act
            await producer.Delete(DbContext);
            
            Producer dbProducer = DbContext.Producers.AsNoTracking().First();
            List<Producer> producerList = DbContext.Producers.AsNoTracking().ToList();
            List<ProducerVersion> producerVersionList = DbContext.ProducerVersions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbProducer);
            
            Assert.AreEqual(1, producerList.Count);
            Assert.AreEqual(2, producerVersionList.Count);
            
            Assert.AreEqual(producer.Address, dbProducer.Address);
            Assert.AreEqual(producer.City, dbProducer.City);
            Assert.AreEqual(producer.Description, dbProducer.Description);
            Assert.AreEqual(producer.Name, dbProducer.Name);
            Assert.AreEqual(producer.Phone, dbProducer.Phone);
            Assert.AreEqual(producer.ContactPerson, dbProducer.ContactPerson);
            Assert.AreEqual(producer.ForeignId, dbProducer.ForeignId);
            Assert.AreEqual(producer.ZipCode, dbProducer.ZipCode);
            Assert.AreEqual(Constants.WorkflowStates.Removed, producer.WorkflowState);
        }

        
    }
}