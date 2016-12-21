using System.Collections.ObjectModel;

///<p>User related entities</p>
namespace com.unisys.rms.domain.user
{
    ///<p>Roles that the user can belong to</p>
    public partial class UserRole : RMSEntity
    {
        public ObservableCollection<FunctionRole> Functions
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

        public ObservableCollection<ResourceRole> Resources
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



