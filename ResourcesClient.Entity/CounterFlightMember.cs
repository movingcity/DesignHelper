
using System.Collections.ObjectModel;
using com.unisys.rms.domain.resource;
using System;
using com.unisys.rms.domain.task;
using com.unisys.rms.domain.flight;
using System.Collections;
using System.Collections.Generic;
using ResourcesClient.Entity.Util;





///<p>Allocation template related entities</p>
// @generated
namespace com.unisys.rms.domain.template
{

	
	///<p>Template flight members for Counter module</p>
	// @wasgenerated
	public partial class CounterFlightMember : FlightMember
	{


		// @generated
		private String depFlightNumber;



		//@wasgenerated
		private string allocIndicator;



		///<p>List of counters associated with this allocation template</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.resource.Counter
		private ObservableCollection<Counter> counters;



		///<p>Departure Flight number for template flight record.</p>
		// @generated
		public String DepFlightNumber
		{

			get
			{
				return depFlightNumber;
			}

			set
			{
				SetField(ref depFlightNumber, value, () => DepFlightNumber);
			}

		}


	

		///<p>The allocation indicator for the template - Domestic or International</p>
		// @generated
		public IndicatorType AllocIndicator
		{

			get
			{
				return EnumHelper.EnumFromValue<IndicatorType>(allocIndicator);
			}

			set
			{
				SetEnumField(ref allocIndicator, value, () => AllocIndicator);
			}

		}



	
	}
	

}



