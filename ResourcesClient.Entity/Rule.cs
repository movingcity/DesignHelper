
using com.unisys.rms.domain;
using System;
using com.unisys.rms.domain.reference;
using ResourcesClient.Entity.Util;





///<p>Criteria related entities</p>
// @generated
namespace com.unisys.rms.domain.criteria
{

	
	///<p>A Rule to be used for allocation</p>
	// @wasgenerated
	public partial class Rule : RMSEntity
	{


		// @generated
		private String name;



		// @generated
		private String description;



		// @generated
		private String localDesc;



		//@wasgenerated
		private string type;



		//@wasgenerated
		private string enabled;



		//@wasgenerated
		private string enableByUser;



		// @generated
		private Clause clause;



		// @generated
		private ConflictCategory category;



		//@wasgenerated
		private string preference;



		// @generated
		private int? weight;



		// @generated
		private Rulebase rulebase;



		//@wasgenerated
		private string isSystem;



		///<p>The unique name of the rule</p>
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


	

		///<p>Full description of the rule</p>
		// @generated
		public String Description
		{

			get
			{
				return description;
			}

			set
			{
				SetField(ref description, value, () => Description);
			}

		}


	

		///<p>Localized description of rule</p>
		// @generated
		public String LocalDesc
		{

			get
			{
				return localDesc;
			}

			set
			{
				SetField(ref localDesc, value, () => LocalDesc);
			}

		}


	

		///<p>The type of the rule</p>
		// @generated
		public RuleType Type
		{

			get
			{
				return EnumHelper.EnumFromValue<RuleType>(type);
			}

			set
			{
				SetEnumField(ref type, value, () => Type);
			}

		}


	

		///<p>Whether rule is enabled</p>
		// @generated
		public bool Enabled
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(enabled);
			}

			set
			{
				SetBoolField(ref enabled, value, () => Enabled);
			}

		}


	

		///<p>Whether rule can be enabled by Gantt user</p>
		// @generated
		public bool EnableByUser
		{

			get
			{
				return BoolHelper.BoolFromValue<bool>(enableByUser);
			}

			set
			{
				SetBoolField(ref enableByUser, value, () => EnableByUser);
			}

		}


	

		///<p>The root clause of the rule</p>
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


	

		///<p>If type is Mandatory, conflict category needs to be provided</p>
		// @generated
		public ConflictCategory Category
		{

			get
			{
				return category;
			}

			set
			{
				SetField(ref category, value, () => Category);
			}

		}


	

		///<p>If type is Preference, then type of preference (cost/benefit) is mandatory</p>
		// @generated
		public PreferenceType? Preference
		{

			get
			{
				return EnumHelper.EnumFromValue<PreferenceType?>(preference);
			}

			set
			{
				SetEnumField(ref preference, value, () => Preference);
			}

		}


	

		///<p>If type is Preference, then weight is mandatory as a positive or negative number</p>
		// @generated
		public int? Weight
		{

			get
			{
				return weight;
			}

			set
			{
				SetField(ref weight, value, () => Weight);
			}

		}


	

		// @generated
		public Rulebase Rulebase
		{

			get
			{
				return rulebase;
			}

			set
			{
				SetField(ref rulebase, value, () => Rulebase);
			}

		}


	

		///<p>If present and true, indicates that the Rule is system created</p>
		// @generated
		public bool? IsSystem
		{

			get
			{
				return BoolHelper.BoolFromValue<bool?>(isSystem);
			}

			set
			{
				SetBoolField(ref isSystem, value, () => IsSystem);
			}

		}



	
	}
	

}



