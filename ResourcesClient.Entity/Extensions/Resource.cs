using System.Collections.ObjectModel;
using System.Text;

///<p>Resource related entities</p>
namespace com.unisys.rms.domain.resource
{
    ///<p>Abstract Airport Resource that can be allocated to a task</p>
    public abstract partial class Resource : RMSEntity
    {
        public ObservableCollection<Resource> NearbyList
        {
            get
            {
                return nearbyList;
            }
            set
            {
                SetField(ref nearbyList, value, () => NearbyList);
            }
        }

        #region Non domain model methods for optimization at client

        public string Name
        {
            get
            {
                StringBuilder builder = new StringBuilder(description);
                builder.Append("(").Append(code).Append(")");
                return builder.ToString();
            }
        }

        #endregion
    }
}



