namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class Log : BaseTrashInspectionEntity
    {
        public int Level { get; set; }

        public string Type { get; set; }

        public string Message { get; set; }
    }
}