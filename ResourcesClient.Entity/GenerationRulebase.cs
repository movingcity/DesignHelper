
using com.unisys.rms.domain;
using com.unisys.rms.domain.resource;
using System;
using ResourcesClient.Entity.Util;





///<p>Task generation entities</p>
// @generated
namespace com.unisys.rms.domain.task.generate
{

	
	///<p>This entity is used to define a unique generation setting and rule to be used to generate tasks.<br></br>Multiple generation rulebase can exist and each has a specific validity period.</p>
	// @wasgenerated
	public partial class GenerationRulebase : RMSEntity
	{


		//@wasgenerated
		private string module;



		// @generated
		private String name;



		// @generated
		private String description;



		// @generated
		private DateTime validityStart;



		// @generated
		private DateTime validityEnd;



		// @generated
		private GenerationRule rule;



		// @generated
		private GenerationSetting setting;



		///<p>The module that this Generation Rulebase belongs to - Stand/Gate/Carousel/Counter</p>
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


	

		///<p>The unique name of this rulebase</p>
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


	

		///<p>Description of the generation rulebase</p>
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


	

		///<p>The rulebase validity end date</p>
		// @generated
		public DateTime ValidityStart
		{

			get
			{
				return validityStart;
			}

			set
			{
				SetField(ref validityStart, value, () => ValidityStart);
			}

		}


	

		///<p>The rulebase validity start date</p>
		// @generated
		public DateTime ValidityEnd
		{

			get
			{
				return validityEnd;
			}

			set
			{
				SetField(ref validityEnd, value, () => ValidityEnd);
			}

		}


	

		///<p>The rule which is used to match flights for generating tasks</p>
		// @generated
		public GenerationRule Rule
		{

			get
			{
				return rule;
			}

			set
			{
				SetField(ref rule, value, () => Rule);
			}

		}


	

		///<p>The generation setting which is used to generate tasks for matching flights</p>
		// @generated
		public GenerationSetting Setting
		{

			get
			{
				return setting;
			}

			set
			{
				SetField(ref setting, value, () => Setting);
			}

		}



	
	}
	

}



