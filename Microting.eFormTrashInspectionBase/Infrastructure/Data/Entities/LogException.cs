using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class LogException : BaseEntity
    {
        public int Level { get; set; }

        public string Type { get; set; }

        public string Message { get; set; }
    }
}