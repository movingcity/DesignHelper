using System.Collections.ObjectModel;

///<p>Entities related to attributes used in Criteria entities (simple expressions). This is static reference data</p>
namespace com.unisys.rms.domain.criteria.attribute
{
    ///<p>A category of attributes. Attributes are grouped as per the Entity that they belong to</p>
    public partial class Category : RMSEntity
    {
        public ObservableCollection<RMSAttribute> Attributes
        {
            get
            {
                return attributes;
            }
            set
            {
                SetField(ref attributes, value, () => Attributes);
            }
        }
    }
}



