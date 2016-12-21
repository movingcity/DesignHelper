
using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using com.unisys.rms.domain.criteria.group;
using com.unisys.rms.domain.resource;
using System;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Criteria related entities</p>
// @generated
namespace com.unisys.rms.domain.criteria
{

	
	///<p>A grouping of the Rules. Only one Rulebase can be active at a time</p>
	// @wasgenerated
	public partial class Rulebase : RMSEntity
	{


		//@wasgenerated
		private string module;



		// @generated
		private String name;



		// @generated
		private String localName;



		//@wasgenerated
		private string active;



		///<p>List of rules present in this Rulebase</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.criteria.Rule
		private ObservableCollection<Rule> rules;



		///<p>List of groups available for use in Rules within this Rulebase</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.criteria.group.RuleGroup
		private ObservableCollection<RuleGroup> groups;



		///<p>The module that this Rulebase belongs to - Stand/Gate/Carousel/Counter</p>
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


	

		///<p>The unique name of the Rulebase</p>
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


	

		///<p>Localized name for the rulebase</p>
		// @generated
		public String LocalName
		{

			get
			{
				return localName;
			}

			set
			{
				SetField(ref localName, value, () => LocalName);
			}

		}


	

		///<p>Whether the rule base is active. Only one rulebase can be active at a time</p>
		// @generated
		public bool Active
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(active);
			}

			set
			{
				SetBoolField(ref active, value, () => Active);
			}

		}



	
	}
	

}



