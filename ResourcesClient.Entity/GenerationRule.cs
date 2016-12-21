
using com.unisys.rms.domain;
using com.unisys.rms.domain.resource;
using System;
using com.unisys.rms.domain.criteria;
using ResourcesClient.Entity.Util;





///<p>Task generation entities</p>
// @generated
namespace com.unisys.rms.domain.task.generate
{

	
	///<p>A rule which is used to match flights for generating tasks for a specific module</p>
	// @wasgenerated
	public partial class GenerationRule : RMSEntity
	{


		//@wasgenerated
		private string module;



		// @generated
		private String name;



		// @generated
		private int priority;



		// @generated
		private Clause clause;



		// @generated
		private GenerationRulebase rulebase;



		///<p>The module that this Generation Rule belongs to - Stand/Gate/Carousel/Counter</p>
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


	

		///<p>The priority of this rule. Higher priority rules are evaluated before lower priority rules. Possible values, 0 - lowest and 5 - highest.<br></br>Note: Priority zero is reserved for system generated rules and not for the user.</p>
		// @generated
		public int Priority
		{

			get
			{
				return priority;
			}

			set
			{
				SetField(ref priority, value, () => Priority);
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


	

		///<p>The rulebase (if any) that this rule is associated with</p>
		// @generated
		public GenerationRulebase Rulebase
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



	
	}
	

}



