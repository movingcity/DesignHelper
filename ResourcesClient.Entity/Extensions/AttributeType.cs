using System.Collections.ObjectModel;

///<p>Entities related to attributes used in Criteria entities (simple expressions). This is static reference data</p>
namespace com.unisys.rms.domain.criteria.attribute
{
    ///<p>Available types of Attributes which have associated allowed operators</p>
    public partial class AttributeType : RMSEntity
    {
        public ObservableCollection<Operator> Operators
        {
            get
            {
                return operators;
            }
            set
            {
                SetField(ref operators, value, () => Operators);
            }
        }
    }
}



