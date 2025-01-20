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
    public class SegmentUTest : DbTestFixture
    {
        [Test]
        public async Task SegmentModel_Save_DoesSave()
        {
            //Arrange
            Random rnd = new Random();

            Segment segmentModel = new Segment
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                SdkFolderId = rnd.Next(1, 255)
            };

            //Act
            await segmentModel.Create(DbContext);

            Segment dbSegment = DbContext.Segments.AsNoTracking().First();
            List<Segment> segmentList = DbContext.Segments.AsNoTracking().ToList();

            //Assert
            Assert.That(dbSegment, Is.Not.Null);

            Assert.That(segmentList.Count(), Is.EqualTo(1));

            Assert.That(dbSegment.Name, Is.EqualTo(segmentModel.Name));
            Assert.That(dbSegment.Description, Is.EqualTo(segmentModel.Description));
            Assert.That(dbSegment.SdkFolderId, Is.EqualTo(segmentModel.SdkFolderId));
        }

        [Test]
        public async Task SegmentModel_Update_DoesUpdate()
        {
            //Arrange
            Random rnd = new Random();

            Segment segment = new Segment
            {
                CreatedAt = DateTime.Now,
                Description = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                SdkFolderId = rnd.Next(1, 255)
            };

            await segment.Create(DbContext);

            //Act

            segment.Name = "New segment name";

            await segment.Update(DbContext);

            Segment dbSegment = DbContext.Segments.AsNoTracking().First();
            List<Segment> segmentList = DbContext.Segments.AsNoTracking().ToList();
            List<SegmentVersion> segmentVersions = DbContext.SegmentVersions.AsNoTracking().ToList();

            //Assert
            Assert.That(dbSegment, Is.Not.Null);

            Assert.That(segmentList.Count(), Is.EqualTo(1));
            Assert.That(segmentVersions.Count(), Is.EqualTo(2));

            Assert.That(dbSegment.Name, Is.EqualTo(segment.Name));
            Assert.That(dbSegment.Description, Is.EqualTo(segment.Description));
            Assert.That(dbSegment.SdkFolderId, Is.EqualTo(segment.SdkFolderId));
        }
        [Test]
        public async Task SegmentModel_Delete_DoesDelete()
        {
            //Arrange
            Random rnd = new Random();

            Segment segment = new Segment
            {
                CreatedAt = DateTime.Now,
                Description = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                SdkFolderId = rnd.Next(1, 255)
            };

            await segment.Create(DbContext);

            //Act

            await segment.Delete(DbContext);

            Segment dbSegment = DbContext.Segments.AsNoTracking().First();
            List<Segment> segmentList = DbContext.Segments.AsNoTracking().ToList();
            List<SegmentVersion> segmentVersions = DbContext.SegmentVersions.AsNoTracking().ToList();

            //Assert
            Assert.That(dbSegment, Is.Not.Null);

            Assert.That(segmentList.Count(), Is.EqualTo(1));
            Assert.That(segmentVersions.Count(), Is.EqualTo(2));

            Assert.That(dbSegment.Name, Is.EqualTo(segment.Name));
            Assert.That(dbSegment.Description, Is.EqualTo(segment.Description));
            Assert.That(dbSegment.SdkFolderId, Is.EqualTo(segment.SdkFolderId));
            Assert.That(Constants.WorkflowStates.Removed, Is.EqualTo(dbSegment.WorkflowState));
        }
    }
}