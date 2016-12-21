
using System.Collections.ObjectModel;
using com.unisys.rms.domain.user;
using com.unisys.rms.domain.resource;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Entities related to grouping of data to be used in the criteria.</p>
// @generated
namespace com.unisys.rms.domain.criteria.group
{

	
	///<p>Group of data items to be used in a Query Criteria value field</p>
	// @wasgenerated
	public partial class QueryGroup : RuleGroup
	{


		//@wasgenerated
		private string module;



		///<p>List of users who the query group is published to. </p>
		// @generated
		// @collection_type:com.unisys.rms.domain.user.User
		private ObservableCollection<User> users;



		///<p>List of user roles who the query group is published to</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.user.UserRole
		private ObservableCollection<UserRole> roles;



		// @generated
		private User creator;



		///<p>The module that this Query Group belongs to - Stand/Gate/Carousel/Counter</p>
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


	

		///<p>Creator (owner) of the query group</p>
		// @generated
		public User Creator
		{

			get
			{
				return creator;
			}

			set
			{
				SetField(ref creator, value, () => Creator);
			}

		}



	
	}
	

}



