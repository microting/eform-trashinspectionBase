namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class TrashInspectionPnSetting: BaseEntity
    {
        public int? SelectedeFormId { get; set; }
        
        public string SelectedeFormName { get; set; }
        
        public string Token { get; set; }
    }
}