
using System.Collections.ObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Entities related to grouping of data to be used in the criteria.</p>
// @generated
namespace com.unisys.rms.domain.criteria.group
{

	
	///<p>Group of data items to be used in a Rule Criteria value field</p>
	// @wasgenerated
	public partial class RuleGroup : Item
	{


		// @generated
		private String name;



		//@wasgenerated
		private string type;



		///<p>Items contained in this group</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.criteria.group.Item
		private ObservableCollection<Item> items;



		///<p>The unique name of the group</p>
		// @generated
		public String Name
		{

			get
			{
				return name;
			}

			set
			{
				SetField(ref name, value, () => Name);
			}

		}


	

		///<p>The category/type of the group</p>
		// @generated
		public GroupType Type
		{

			get
			{
				return EnumHelper.EnumFromValue<GroupType>(type);
			}

			set
			{
				SetEnumField(ref type, value, () => Type);
			}

		}


	
	
		// @generated
		public override bool Contains(String value)
		{
			//TODO: Auto-generated method stub
			throw new System.NotImplementedException();
		}
	


	}
	

}



