using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class InstallationSite : BaseEntity
    {
        public int Version { get; set; }
        
        [ForeignKey("Installation")]
        public int InstallationId { get; set; }

        public int SDKSiteId { get; set; }
    }
}