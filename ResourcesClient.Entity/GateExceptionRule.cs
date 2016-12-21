
using com.unisys.rms.domain;
using System.Collections.ObjectModel;
using com.unisys.rms.domain.resource;
using com.unisys.rms.domain.reference;
using com.unisys.rms.domain.flight;
using System;
using ResourcesClient.Entity.Util;





///<p>Task related entities</p>
// @generated
namespace com.unisys.rms.domain.task
{

	
	///<p>A rule which defines exceptions to enforce default gate for stand.<br>This entity defines alternates to the default gates defined for a stand.<br>When an allocation violates the criteria defined by this rule, a conflict should be raised for that Gate Task.</p><p>When a stand task allocation takes place, the departure flight terminal, flight category and allocated stand are used to determine matching rule.<br></br>Gate allocations must match the gates defined in this rule.</p>
	/// @wasgenerated
	public partial class GateExceptionRule : RMSEntity
	{


		// @generated
		private Terminal terminal;



		//@wasgenerated
		private string flightCategory;



		///<p>List of stands, out of which the matching departure flight stand task should be allocated to one.</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.resource.Stand
		private ObservableCollection<Stand> stands;



		///<p>List of allowed domestic gates for matching stand task allocations. One of domGates or intlGates is mandatory.</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.resource.Gate
		private ObservableCollection<Gate> domGates;



		///<p>List of allowed international gates for matching stand task allocations. One of domGates or intlGates is mandatory.</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.resource.Gate
		private ObservableCollection<Gate> intlGates;



		// @generated
		private ConflictCategory category;



		// @generated
		private String conflictText;



		///<p>Terminal from which the matching stand task flight departs from</p>
		// @generated
		public Terminal Terminal
		{

			get
			{
				return terminal;
			}

			set
			{
				SetField(ref terminal, value, () => Terminal);
			}

		}


	

		///<p>Flight indicator of the matching stand task departure flight</p>
		// @generated
		public FlightIndicatorType FlightCategory
		{

			get
			{
				return EnumHelper.EnumFromValue<FlightIndicatorType>(flightCategory);
			}

			set
			{
				SetEnumField(ref flightCategory, value, () => FlightCategory);
			}

		}


	

		///<p>The category of conflict raised when this rule is broken</p>
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


	

		///<p>Free text associated with the conflict when this rule is broken</p>
		// @generated
		public String ConflictText
		{

			get
			{
				return conflictText;
			}

			set
			{
				SetField(ref conflictText, value, () => ConflictText);
			}

		}



	
	}
	

}



