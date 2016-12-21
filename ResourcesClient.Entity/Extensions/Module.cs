using System.Collections.ObjectModel;

///<p>Entities related to attributes used in Criteria entities (simple expressions). This is static reference data</p>
namespace com.unisys.rms.domain.criteria.attribute
{
    ///<p>A list of categories that are available for a module (Stand/Gate/Counter/Carousel)</p>
    public partial class Module : RMSEntity
    {
        public ObservableCollection<Category> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                SetField(ref categories, value, () => Categories);
            }
        }
    }
}



