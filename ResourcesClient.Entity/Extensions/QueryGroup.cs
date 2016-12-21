using System.Collections.ObjectModel;
using com.unisys.rms.domain.user;

///<p>Entities related to grouping of data to be used in the criteria.</p>
namespace com.unisys.rms.domain.criteria.group
{
    ///<p>Group of data items to be used in a Query Criteria value field</p>
    public partial class QueryGroup : RuleGroup
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



