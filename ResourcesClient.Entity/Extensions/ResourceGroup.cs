using System.Collections.ObjectModel;

///<p>Resource related entities</p>
namespace com.unisys.rms.domain.resource
{
    ///<p>A grouping of the Resources for display purposes</p>
    public partial class ResourceGroup : RMSEntity
    {
        public ObservableCollection<Resource> Resources
        {
            get
            {
                return resources;
            }
            set
            {
                SetField(ref resources, value, () => Resources);
            }
        }
    }
}



