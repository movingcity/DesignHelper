using System.Collections.ObjectModel;
using com.unisys.rms.domain.reference;

///<p>Entities related to application batch jobs</p>
namespace com.unisys.rms.domain.system.batch
{
    ///<p>Represents a scheduler job that deletes archived data</p>
    public partial class ArchiveDataJob : SchedulerJob
    {
        public ObservableCollection<Airline> Airlines
        {
            get
            {
                return airlines;
            }
            set
            {
                SetField(ref airlines, value, () => Airlines);
            }
        }
    }
}



