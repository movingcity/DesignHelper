using System.Collections.ObjectModel;
using com.unisys.rms.domain.resource;

///<p>Task related entities</p>
namespace com.unisys.rms.domain.task
{
    ///<p>A rule which defines exceptions to enforce default gate for stand.<br>This entity defines alternates to the default gates defined for a stand.<br>When an allocation violates the criteria defined by this rule, a conflict should be raised for that Gate Task.</p><p>When a stand task allocation takes place, the departure flight terminal, flight category and allocated stand are used to determine matching rule.<br></br>Gate allocations must match the gates defined in this rule.</p>
    public partial class GateExceptionRule : RMSEntity
    {
        public ObservableCollection<Stand> Stands
        {
            get
            {
                return stands;
            }
            set
            {
                SetField(ref stands, value, () => Stands);
            }
        }

        public ObservableCollection<Gate> DomGates
        {
            get
            {
                return domGates;
            }
            set
            {
                SetField(ref domGates, value, () => DomGates);
            }
        }

        public ObservableCollection<Gate> IntlGates
        {
            get
            {
                return intlGates;
            }
            set
            {
                SetField(ref intlGates, value, () => IntlGates);
            }
        }
    }
}



