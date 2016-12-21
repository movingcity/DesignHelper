using System.Collections.ObjectModel;

///<p>Resource related entities</p>
namespace com.unisys.rms.domain.resource
{
    ///<p>List of ResourceGroup entities that are selected for a specified user.<br></br>One user will only have one and only one UserResourceGroup entity (this relationship to be enforced by application).</p><p>Note: This entity is separated from User entity as it is updated independently of the same.</p>
    public partial class UserResourceGroups : RMSEntity
    {
        public ObservableCollection<ResourceGroup> Groups
        {
            get
            {
                return groups;
            }
            set
            {
                SetField(ref groups, value, () => Groups);
            }
        }
    }
}



