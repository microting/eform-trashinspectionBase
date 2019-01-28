using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{

    public class InstallationVersion : BaseEntity
    {
        public int Version { get; set; }
        
        public string Name { get; set; }

        [ForeignKey("Installation")]
        public int InstallationId { get; set; }
    }
}