using System.Collections.ObjectModel;

///<p>Entities related to grouping of data to be used in the criteria.</p>
namespace com.unisys.rms.domain.criteria.group
{
    ///<p>Group of data items to be used in a Rule Criteria value field</p>
    public partial class RuleGroup : Item
    {
        public ObservableCollection<Item> Items
        {
            get
            {
                return items;
            }
            set
            {
                SetField(ref items, value, () => Items);
            }
        }
    }
}



