using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormTrashInspectionBase.Infrastructure.Data.Entities
{
    public class TrashInspectionPnSettingVersion : BaseEntity
    {
        public int? SelectedeFormId { get; set; }
        
        public string SelectedeFormName { get; set; }

        [ForeignKey("TrashInspectionPnSetting")]
        public int TrashInspectionPnSettingId { get; set; }
        
        public string ResponseCallBackUrl { get; set; }
        
        public string SdkConnectionString { get; set; }
    }
}