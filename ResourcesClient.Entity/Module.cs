
using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using com.unisys.rms.domain.resource;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Entities related to attributes used in Criteria entities (simple expressions). This is static reference data</p>
// @generated
namespace com.unisys.rms.domain.criteria.attribute
{

	
	///<p>A list of categories that are available for a module (Stand/Gate/Counter/Carousel)</p>
	// @wasgenerated
	public partial class Module : RMSEntity
	{


		//@wasgenerated
		private string type;



		///<p>Allowed categories for the module</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.criteria.attribute.Category
		private ObservableCollection<Category> categories;



		///<p>Type of the attributes module</p>
		// @generated
		public ResourceType Type
		{

			get
			{
				return EnumHelper.EnumFromValue<ResourceType>(type);
			}

			set
			{
				SetEnumField(ref type, value, () => Type);
			}

		}



	
	}
	

}



