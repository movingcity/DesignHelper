
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

	
	///<p>Template flight members for Carousel module</p>
	// @wasgenerated
	public partial class CarouselFlightMember : FlightMember
	{


		// @generated
		private String arrFlightNumber;



		//@wasgenerated
		private string allocIndicator;



		///<p>List of carousels associated with this allocation template</p>
		// @generated
		// @collection_type:com.unisys.rms.domain.resource.Carousel
		private ObservableCollection<Carousel> carousels;



		///<p>Arrival Flight number for template flight record.</p>
		// @generated
		public String ArrFlightNumber
		{

			get
			{
				return arrFlightNumber;
			}

			set
			{
				SetField(ref arrFlightNumber, value, () => ArrFlightNumber);
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



