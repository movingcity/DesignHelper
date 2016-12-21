
using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using com.unisys.rms.domain.user;
using com.unisys.rms.domain.resource;
using System;
using com.unisys.rms.domain.system;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Criteria related entities</p>
// @generated
namespace com.unisys.rms.domain.criteria
{

	
	///<p>Query which checks various entities and their attributes and returns true/false</p>
	// @wasgenerated
	public partial class Query : RMSEntity
	{


		//@wasgenerated
		private string module;



		// @generated
		private String name;



		// @generated
		private Color color;



		// @generated
		private Clause clause;



		///<p>List of users who the query is published to.</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.user.User
		private ObservableCollection<User> users;



		///<p>List of roles this query is published to.</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.user.UserRole
		private ObservableCollection<UserRole> roles;



		// @generated
		private User creator;



		///<p>The module that this Query belongs to - Stand/Gate/Carousel/Counter</p>
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


	

		///<p>Query name. Unique for a specific user</p>
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


	

		///<p>The highlight color for the query</p>
		// @generated
		public Color Color
		{

			get
			{
				return color;
			}

			set
			{
				SetField(ref color, value, () => Color);
			}

		}


	

		///<p>The root clause of the Query</p>
		// @generated
		public Clause Clause
		{

			get
			{
				return clause;
			}

			set
			{
				SetField(ref clause, value, () => Clause);
			}

		}


	

		///<p>Creator (owner) of the query</p>
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



