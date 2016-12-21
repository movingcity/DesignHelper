
using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using com.unisys.rms.domain.resource;
using System;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Allocation template related entities</p>
// @generated
namespace com.unisys.rms.domain.template
{

	
	///<p>Allocation template for a resource</p>
	// @wasgenerated
	public partial class AllocationTemplate : RMSEntity
	{


		//@wasgenerated
		private string module;



		// @generated
		private String description;



		// @generated
		private DateTime validityStart;



		// @generated
		private DateTime validityEnd;



		///<p>List of Flight members for this template. These members define how the allocation should occur for specific flight parameters</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.template.FlightMember
		private ObservableCollection<FlightMember> members;



		// @generated
		private String name;



		//@wasgenerated
		private string accessType;



		///<p>The module (Stand/Gate/Carousel/Counter) that this template belongs to</p>
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


	

		///<p>Allocation template name</p>
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


	

		///<p>Description of this template</p>
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


	

		///<p>Template validity start date time</p>
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


	

		///<p>Template validity end date time</p>
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


	

		///<p>Allocation template access type</p>
		// @generated
		public TemplateAccessType AccessType
		{

			get
			{
				return EnumHelper.EnumFromValue<TemplateAccessType>(accessType);
			}

			set
			{
				SetEnumField(ref accessType, value, () => AccessType);
			}

		}



	
	}
	

}



