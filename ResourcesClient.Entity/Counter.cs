
using System;
using com.unisys.rms.domain.task;
using ResourcesClient.Entity.Util;





///<p>Resource related entities</p>
// @generated
namespace com.unisys.rms.domain.resource
{

	
	///<p>A counter/desk which is used to check-in departing passengers for a flight.</p>
	// @wasgenerated
	public partial class Counter : Resource
	{


		// @generated
		private String aisle;



		// @generated
		private Counter adjCounter1;



		// @generated
		private Counter adjCounter2;



		// @generated
		private Counter overflow;



		//@wasgenerated
		private string domIntlIndicator;



		// @generated
		private int? maxPax;



		// @generated
		private int? concurrent;



		//@wasgenerated
		private string isTransfer;



		///<p>The name of the aisle used by this desk</p>
		// @generated
		public String Aisle
		{

			get
			{
				return aisle;
			}

			set
			{
				SetField(ref aisle, value, () => Aisle);
			}

		}


	

		///<p>First Counter which is adjacent to this counter</p>
		// @generated
		public Counter AdjCounter1
		{

			get
			{
				return adjCounter1;
			}

			set
			{
				SetField(ref adjCounter1, value, () => AdjCounter1);
			}

		}


	

		///<p>Second Counter which is adjacent to this counter</p>
		// @generated
		public Counter AdjCounter2
		{

			get
			{
				return adjCounter2;
			}

			set
			{
				SetField(ref adjCounter2, value, () => AdjCounter2);
			}

		}


	

		///<p>Overflow desk</p>
		// @generated
		public Counter Overflow
		{

			get
			{
				return overflow;
			}

			set
			{
				SetField(ref overflow, value, () => Overflow);
			}

		}


	

		///<p>Counter category - Domestic/International/Both</p>
		// @generated
		public IndicatorType? DomIntlIndicator
		{

			get
			{
				return EnumHelper.EnumFromValue<IndicatorType?>(domIntlIndicator);
			}

			set
			{
				SetEnumField(ref domIntlIndicator, value, () => DomIntlIndicator);
			}

		}


	

		///<p>Maximum passengers supported</p>
		// @generated
		public int? MaxPax
		{

			get
			{
				return maxPax;
			}

			set
			{
				SetField(ref maxPax, value, () => MaxPax);
			}

		}


	

		///<p>Number of concurrent flights allowed</p>
		// @generated
		public int? Concurrent
		{

			get
			{
				return concurrent;
			}

			set
			{
				SetField(ref concurrent, value, () => Concurrent);
			}

		}


	

		///<p>Whether this is a Transfer CheckinDesk</p>
		// @generated
		public bool? IsTransfer
		{

			get
			{
				return BoolHelper.BoolFromValue<bool?>(isTransfer);
			}

			set
			{
				SetBoolField(ref isTransfer, value, () => IsTransfer);
			}

		}



	
	}
	

}



