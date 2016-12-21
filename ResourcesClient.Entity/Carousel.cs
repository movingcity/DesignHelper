
using com.unisys.rms.domain.task;
using ResourcesClient.Entity.Util;





///<p>Resource related entities</p>
// @generated
namespace com.unisys.rms.domain.resource
{

	
	///<p>A baggage carousel (belt) which is used to deliver checked baggage to the passengers at the baggage claim area of the terminal.</p>
	// @wasgenerated
	public partial class Carousel : Resource
	{


		// @generated
		private Carousel adjCarousel1;



		// @generated
		private Carousel adjCarousel2;



		// @generated
		private Carousel overflow;



		//@wasgenerated
		private string domIntlIndicator;



		// @generated
		private int? maxPax;



		// @generated
		private int? concurrent;



		// @generated
		private int? capacity;



		// @generated
		private int? bagsPM;



		///<p>First carousel adjacent to this one</p>
		// @generated
		public Carousel AdjCarousel1
		{

			get
			{
				return adjCarousel1;
			}

			set
			{
				SetField(ref adjCarousel1, value, () => AdjCarousel1);
			}

		}


	

		///<p>Second carousel adjacent to this one</p>
		// @generated
		public Carousel AdjCarousel2
		{

			get
			{
				return adjCarousel2;
			}

			set
			{
				SetField(ref adjCarousel2, value, () => AdjCarousel2);
			}

		}


	

		///<p>The overflow carousel</p>
		// @generated
		public Carousel Overflow
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


	

		///<p>Carousel category - Domestic/International/Both</p>
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


	

		///<p>The maximum capacity (bags)</p>
		// @generated
		public int? Capacity
		{

			get
			{
				return capacity;
			}

			set
			{
				SetField(ref capacity, value, () => Capacity);
			}

		}


	

		///<p>The maximum rate bags can flow onto the belt</p>
		// @generated
		public int? BagsPM
		{

			get
			{
				return bagsPM;
			}

			set
			{
				SetField(ref bagsPM, value, () => BagsPM);
			}

		}



	
	}
	

}



