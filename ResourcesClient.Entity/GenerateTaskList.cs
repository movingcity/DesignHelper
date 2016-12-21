
using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using ResourcesClient.Entity.Util;





///<p>Task generation entities</p>
// @generated
namespace com.unisys.rms.domain.task.generate
{

	
	///<p>A list of items used to generate tasks. </p><p>Absolute time list items will specify absolute time for the task to be generated. Flight time list items will specify time relative to flight operation time.<br></br>Absolute list - Time will be specified in minutes from 0000 hours for the day in question.<br></br>Flight relative list - Time will be specified in minutes relative to flight operation time.</p>
	// @wasgenerated
	public partial class GenerateTaskList : RMSEntity
	{


		//@wasgenerated
		private string type;



		///<p>The generate task items list</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.task.generate.GenerateTaskItem
		private ObservableCollection<GenerateTaskItem> items;



		///<p>The type of generate task items list</p>
		// @generated
		public GenerateListType Type
		{

			get
			{
				return EnumHelper.EnumFromValue<GenerateListType>(type);
			}

			set
			{
				SetEnumField(ref type, value, () => Type);
			}

		}



	
	}
	

}



