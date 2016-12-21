using System.Collections.ObjectModel;
using com.unisys.rms.domain.user;

///<p>Criteria related entities</p>
namespace com.unisys.rms.domain.criteria
{
    ///<p>Query which checks various entities and their attributes and returns true/false</p>
    public partial class Query : RMSEntity
    {
        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                SetField(ref users, value, () => Users);
            }
        }

        public ObservableCollection<UserRole> Roles
        {
            get
            {
                return roles;
            }
            set
            {
                SetField(ref roles, value, () => Roles);
            }
        }
    }
}



