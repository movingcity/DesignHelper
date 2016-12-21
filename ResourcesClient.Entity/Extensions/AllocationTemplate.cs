using System.Collections.ObjectModel;

///<p>Allocation template related entities</p>
namespace com.unisys.rms.domain.template
{
    ///<p>Allocation template for a resource</p>
    public partial class AllocationTemplate : RMSEntity
    {
        public ObservableCollection<FlightMember> Members
        {
            get
            {
                return members;
            }
            set
            {
                SetField(ref members, value, () => Members);
            }
        }
    }
}



