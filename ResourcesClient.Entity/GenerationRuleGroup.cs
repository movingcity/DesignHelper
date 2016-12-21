
using com.unisys.rms.domain.criteria.group;
using com.unisys.rms.domain.resource;
using ResourcesClient.Entity.Util;





///<p>Task generation entities</p>
// @generated
namespace com.unisys.rms.domain.task.generate
{

	
	///<p>Group of data items to be used in a GenerationRule Criteria value field</p>
	// @wasgenerated
	public partial class GenerationRuleGroup : RuleGroup
	{


		//@wasgenerated
		private string module;



		///<p>The module that this Generation Rule Group belongs to - Stand/Gate/Carousel/Counter</p>
		// @generated
		public ResourceType Module
		{

			get
			{
				return EnumHelper.EnumFromValue<ResourceType>(module);
			}

			set
			{
				SetEnumField(ref module, value, () => Module);
			}

		}



	
	}
	

}



