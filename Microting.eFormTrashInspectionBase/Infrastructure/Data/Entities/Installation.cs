using System;
using System.ComponentModel.DataAnnotations;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Installation : BaseEntity
    {

        public int Version { get; set; }

        public string Name { get; set; }
    }
}