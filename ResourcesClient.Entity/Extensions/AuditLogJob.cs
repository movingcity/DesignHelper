using System.Collections.ObjectModel;
using com.unisys.rms.domain.user;

///<p>Entities related to application batch jobs</p>
namespace com.unisys.rms.domain.system.batch
{
    ///<p>Represents a scheduler job that deletes audit data</p>
    public partial class AuditLogJob : SchedulerJob
    {
        public ObservableCollection<Function> Functions
        {
            get
            {
                return functions;
            }
            set
            {
                SetField(ref functions, value, () => Functions);
            }
        }
    }
}



