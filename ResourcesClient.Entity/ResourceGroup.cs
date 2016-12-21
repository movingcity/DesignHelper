
using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using System;
using com.unisys.rms.domain.user;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Resource related entities</p>
// @generated
namespace com.unisys.rms.domain.resource
{

	
	///<p>A grouping of the Resources for display purposes</p>
	// @wasgenerated
	public partial class ResourceGroup : RMSEntity
	{


		//@wasgenerated
		private string module;



		// @generated
		private String name;



		//@wasgenerated
		private string allUsers;



		///<p>List of resources belonging to this resource display group</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.resource.Resource
		private ObservableCollection<Resource> resources;



		// @generated
		private User user;



		///<p>The module that this Resource display group belongs to - Stand/Gate/Carousel/Counter</p><p></p>
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


	

		///<p>Resource display group code</p>
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


	

		///<p>Is the Resource display group available to other users?</p>
		// @generated
		public bool AllUsers
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(allUsers);
			}

			set
			{
				SetBoolField(ref allUsers, value, () => AllUsers);
			}

		}


	

		///<p>User-name who created this group</p>
		// @generated
		public User User
		{

			get
			{
				return user;
			}

			set
			{
				SetField(ref user, value, () => User);
			}

		}



	
	}
	

}



