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
            Producer producer = new Producer
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
            await producer.Create(DbContext);

            Producer dbProducer = DbContext.Producers.AsNoTracking().First();
            List<Producer> producerList = DbContext.Producers.AsNoTracking().ToList();
            List<ProducerVersion> producerVersionList = DbContext.ProducerVersions.AsNoTracking().ToList();
            //Assert
            Assert.That(dbProducer, Is.Not.Null);

            Assert.That(producerList.Count, Is.EqualTo(1));
            Assert.That(producerVersionList.Count, Is.EqualTo(1));

            Assert.That(dbProducer.Address, Is.EqualTo(producer.Address));
            Assert.That(dbProducer.City, Is.EqualTo(producer.City));
            Assert.That(dbProducer.Description, Is.EqualTo(producer.Description));
            Assert.That(dbProducer.Name, Is.EqualTo(producer.Name));
            Assert.That(dbProducer.Phone, Is.EqualTo(producer.Phone));
            Assert.That(dbProducer.ContactPerson, Is.EqualTo(producer.ContactPerson));
            Assert.That(dbProducer.ForeignId, Is.EqualTo(producer.ForeignId));
            Assert.That(dbProducer.ZipCode, Is.EqualTo(producer.ZipCode));
        }
        [Test]
        public async Task Producer_Update_DoesUpdate()
        {
            //Arrange
            Producer producer = new Producer
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
            Assert.That(dbProducer, Is.Not.Null);

            Assert.That(producerList.Count, Is.EqualTo(1));
            Assert.That(producerVersionList.Count, Is.EqualTo(2));

            Assert.That(dbProducer.Address, Is.EqualTo(newAddress));
            Assert.That(dbProducer.City, Is.EqualTo(newCity));
            Assert.That(dbProducer.Description, Is.EqualTo(newDescription));
            Assert.That(dbProducer.Name, Is.EqualTo(newName));
            Assert.That(dbProducer.Phone, Is.EqualTo(newPhone));
            Assert.That(dbProducer.ContactPerson, Is.EqualTo(newContactPerson));
            Assert.That(dbProducer.ForeignId, Is.EqualTo(newForeignId));
            Assert.That(dbProducer.ZipCode, Is.EqualTo(newZipCode));
        }
        [Test]
        public async Task Producer_Delete_DoesDelete()
        {
            //Arrange
            Producer producer = new Producer
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

            await producer.Create(DbContext);

            //Act
            await producer.Delete(DbContext);

            Producer dbProducer = DbContext.Producers.AsNoTracking().First();
            List<Producer> producerList = DbContext.Producers.AsNoTracking().ToList();
            List<ProducerVersion> producerVersionList = DbContext.ProducerVersions.AsNoTracking().ToList();
            //Assert
            Assert.That(dbProducer, Is.Not.Null);

            Assert.That(producerList.Count, Is.EqualTo(1));
            Assert.That(producerVersionList.Count, Is.EqualTo(2));

            Assert.That(dbProducer.Address, Is.EqualTo(producer.Address));
            Assert.That(dbProducer.City, Is.EqualTo(producer.City));
            Assert.That(dbProducer.Description, Is.EqualTo(producer.Description));
            Assert.That(dbProducer.Name, Is.EqualTo(producer.Name));
            Assert.That(dbProducer.Phone, Is.EqualTo(producer.Phone));
            Assert.That(dbProducer.ContactPerson, Is.EqualTo(producer.ContactPerson));
            Assert.That(dbProducer.ForeignId, Is.EqualTo(producer.ForeignId));
            Assert.That(dbProducer.ZipCode, Is.EqualTo(producer.ZipCode));
            Assert.That(producer.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
        }


    }
}