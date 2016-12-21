
using com.unisys.rms.domain;
using com.unisys.rms.domain.resource;
using System;
using ResourcesClient.Entity.Util;





///<p>Task generation entities</p>
// @generated
namespace com.unisys.rms.domain.task.generate
{

	
	///<p>Defines the settings to be used to generate tasks for a module.<br></br>Tasks are generated when flight matches a generation rule of a matching rulebase.</p>
	// @wasgenerated
	public partial class GenerationSetting : RMSEntity
	{


		//@wasgenerated
		private string module;



		// @generated
		private String name;



		// @generated
		private String description;



		// @generated
		private GenerationRulebase rulebase;



		// @generated
		private GenerateTaskList monItems;



		// @generated
		private GenerateTaskList tueItems;



		// @generated
		private GenerateTaskList wedItems;



		// @generated
		private GenerateTaskList thuItems;



		// @generated
		private GenerateTaskList friItems;



		// @generated
		private GenerateTaskList satItems;



		// @generated
		private GenerateTaskList sunItems;



		///<p>The module that this Generation Setting belongs to - Stand/Gate/Carousel/Counter</p>
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


	

		///<p>Unique name of the generation setting</p>
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


	

		///<p>Description of the generation setting</p>
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


	

		///<p>The rulebase (if any) that this setting is associated with</p>
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


	

		///<p>Generate Task items list for Monday. One of the 7 values is mandatory.</p>
		// @generated
		public GenerateTaskList MonItems
		{

			get
			{
				return monItems;
			}

			set
			{
				SetField(ref monItems, value, () => MonItems);
			}

		}


	

		///<p>Generate Task items list for Tuesday. One of the 7 values is mandatory.</p>
		// @generated
		public GenerateTaskList TueItems
		{

			get
			{
				return tueItems;
			}

			set
			{
				SetField(ref tueItems, value, () => TueItems);
			}

		}


	

		///<p>Generate Task items list for Wednesday. One of the 7 values is mandatory.</p>
		// @generated
		public GenerateTaskList WedItems
		{

			get
			{
				return wedItems;
			}

			set
			{
				SetField(ref wedItems, value, () => WedItems);
			}

		}


	

		///<p>Generate Task items list for Thursday. One of the 7 values is mandatory.</p>
		// @generated
		public GenerateTaskList ThuItems
		{

			get
			{
				return thuItems;
			}

			set
			{
				SetField(ref thuItems, value, () => ThuItems);
			}

		}


	

		///<p>Generate Task items list for Friday. One of the 7 values is mandatory.</p>
		// @generated
		public GenerateTaskList FriItems
		{

			get
			{
				return friItems;
			}

			set
			{
				SetField(ref friItems, value, () => FriItems);
			}

		}


	

		///<p>Generate Task items list for Saturday. One of the 7 values is mandatory.</p>
		// @generated
		public GenerateTaskList SatItems
		{

			get
			{
				return satItems;
			}

			set
			{
				SetField(ref satItems, value, () => SatItems);
			}

		}


	

		///<p>Generate Task items list for Sunday. One of the 7 values is mandatory.</p>
		// @generated
		public GenerateTaskList SunItems
		{

			get
			{
				return sunItems;
			}

			set
			{
				SetField(ref sunItems, value, () => SunItems);
			}

		}



	
	}
	

}



