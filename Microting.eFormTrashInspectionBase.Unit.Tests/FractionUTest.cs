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
    public class FractionUTest : DbTestFixture
    {
        [Test]
        public async Task FractionModel_Save_DoesSave()
        {
            //Arrange
            Random rnd = new Random();

            Fraction fraction = new Fraction
            {
                CreatedAt = DateTime.Now,
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                eFormId = rnd.Next(1, 255)
            };

            //Act
            await fraction.Create(DbContext);

            Fraction dbFraction = DbContext.Fractions.AsNoTracking().First();
            List<Fraction> fractionList = DbContext.Fractions.AsNoTracking().ToList();
            //Assert
            Assert.NotNull(dbFraction);

            Assert.AreEqual(1, fractionList.Count());

            Assert.AreEqual(fraction.Name, dbFraction.Name);
            Assert.AreEqual(fraction.Description, dbFraction.Description);
            Assert.AreEqual(fraction.eFormId, dbFraction.eFormId);
        }

        [Test]
        public async Task FractionModel_Update_DoesUpdate()
        {
            //Arrange
            Random rnd = new Random();
            Fraction fraction = new Fraction
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                eFormId = rnd.Next(1, 355)
            };

            await DbContext.Fractions.AddAsync(fraction);
            await DbContext.SaveChangesAsync();

            //Act
            fraction.Name = Guid.NewGuid().ToString();

            await fraction.Update(DbContext);

            Fraction dbFraction = DbContext.Fractions.AsNoTracking().First();
            List<Fraction> fractionList = DbContext.Fractions.AsNoTracking().ToList();
            List<FractionVersion> fractionVersions = DbContext.FractionVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbFraction);

            Assert.AreEqual(1, fractionList.Count());
            Assert.AreEqual(1, fractionVersions.Count());

            Assert.AreEqual(fraction.Name, dbFraction.Name);
            Assert.AreEqual(fraction.Description, dbFraction.Description);
            Assert.AreEqual(fraction.eFormId, dbFraction.eFormId);
            Assert.AreEqual(fraction.CreatedAt, dbFraction.CreatedAt);
        }
        [Test]
        public async Task FractionModel_Delete_DoesSetWorkflowStateToRemoved()
        {
            //Arrange
            Random rnd = new Random();
            Fraction fraction = new Fraction
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                eFormId = rnd.Next(1, 355)
            };

            await DbContext.Fractions.AddAsync(fraction);
            await DbContext.SaveChangesAsync();

            //Act
            await fraction.Delete(DbContext);

            Fraction dbFraction = DbContext.Fractions.AsNoTracking().First();
            List<Fraction> fractionList = DbContext.Fractions.AsNoTracking().ToList();
            List<FractionVersion> fractionVersions = DbContext.FractionVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(dbFraction);

            Assert.AreEqual(1, fractionList.Count());
            Assert.AreEqual(1, fractionVersions.Count());

            Assert.AreEqual(fraction.Name, dbFraction.Name);
            Assert.AreEqual(fraction.Description, dbFraction.Description);
            Assert.AreEqual(fraction.eFormId, dbFraction.eFormId);
            Assert.AreEqual(fraction.CreatedAt, dbFraction.CreatedAt);
            Assert.AreEqual(dbFraction.WorkflowState, Constants.WorkflowStates.Removed);
        }

    }
}