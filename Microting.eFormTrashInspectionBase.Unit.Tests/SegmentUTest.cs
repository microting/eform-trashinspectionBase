using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace Microting.eFormTrashInspectionBase.Unit.Tests
{
    [TestFixture]
    public class SegmentUTest : DbTestFixture
    {
        [Test]
        public void SegmentModel_Save_DoesSave()
        {
            //Arrange 
            Random rnd = new Random();
            
            Segment segmentModel = new Segment();
            segmentModel.Name = Guid.NewGuid().ToString();
            segmentModel.Description = Guid.NewGuid().ToString();
            segmentModel.SdkFolderId = rnd.Next(1, 255);
            
            //Act
            segmentModel.Create(DbContext);

            Segment dbSegment = DbContext.Segments.AsNoTracking().First();
            List<Segment> segmentList = DbContext.Segments.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbSegment);

            Assert.AreEqual(1, segmentList.Count());
            
            Assert.AreEqual(segmentModel.Name, dbSegment.Name);
            Assert.AreEqual(segmentModel.Description, dbSegment.Description);
            Assert.AreEqual(segmentModel.SdkFolderId, dbSegment.SdkFolderId);
        }

        [Test]
        public void SegmentModel_Update_DoesUpdate()
        {
            //Arrange
            Random rnd = new Random();
            
            Segment segment = new Segment();
            segment.CreatedAt = DateTime.Now;
            segment.Description = Guid.NewGuid().ToString();
            segment.Name = Guid.NewGuid().ToString();
            segment.SdkFolderId = rnd.Next(1, 255);

            segment.Create(DbContext);

            //Act

            segment.Name = "New segment name";
            
            segment.Update(DbContext);
            
            Segment dbSegment = DbContext.Segments.AsNoTracking().First();
            List<Segment> segmentList = DbContext.Segments.AsNoTracking().ToList();
            List<SegmentVersion> segmentVersions = DbContext.SegmentVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbSegment);

            Assert.AreEqual(1, segmentList.Count());
            Assert.AreEqual(2, segmentVersions.Count());
            
            Assert.AreEqual(segment.Name, dbSegment.Name);
            Assert.AreEqual(segment.Description, dbSegment.Description);
            Assert.AreEqual(segment.SdkFolderId, dbSegment.SdkFolderId);
        }
        [Test]
        public void SegmentModel_Delete_DoesDelete()
        {
            //Arrange
            Random rnd = new Random();
            
            Segment segment = new Segment();
            segment.CreatedAt = DateTime.Now;
            segment.Description = Guid.NewGuid().ToString();
            segment.Name = Guid.NewGuid().ToString();
            segment.SdkFolderId = rnd.Next(1, 255);

            segment.Create(DbContext);

            //Act
            
            segment.Delete(DbContext);
            
            Segment dbSegment = DbContext.Segments.AsNoTracking().First();
            List<Segment> segmentList = DbContext.Segments.AsNoTracking().ToList();
            List<SegmentVersion> segmentVersions = DbContext.SegmentVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(dbSegment);

            Assert.AreEqual(1, segmentList.Count());
            Assert.AreEqual(2, segmentVersions.Count());
            
            Assert.AreEqual(segment.Name, dbSegment.Name);
            Assert.AreEqual(segment.Description, dbSegment.Description);
            Assert.AreEqual(segment.SdkFolderId, dbSegment.SdkFolderId);
            Assert.AreEqual(dbSegment.WorkflowState, eFormShared.Constants.WorkflowStates.Removed);
        }
    }
}