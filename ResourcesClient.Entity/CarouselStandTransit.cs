
using com.unisys.rms.domain;
using com.unisys.rms.domain.resource;





///<p>Carousel resource related entities</p>
// @generated
namespace com.unisys.rms.domain.resource.carousel
{

	
	///<p>Carousel Stand Transit Times define the typical time taken for baggage trucks to move from a set of stands to a set of carousels. Such carousel stand transit times are to be used for adjusting the start time of flight carousel tasks once an arrival flight has landed and/or when an arrival flight has chocked on to a stand.</p>
	// @wasgenerated
	public partial class CarouselStandTransit : RMSEntity
	{


		// @generated
		private Carousel carousel;



		// @generated
		private Stand stand;



		// @generated
		private int transitTime;



		///<p>The carousel to transit to</p>
		// @generated
		public Carousel Carousel
		{

			get
			{
				return carousel;
			}

			set
			{
				SetField(ref carousel, value, () => Carousel);
			}

		}


	

		///<p>The stand to transit from</p>
		// @generated
		public Stand Stand
		{

			get
			{
				return stand;
			}

			set
			{
				SetField(ref stand, value, () => Stand);
			}

		}


	

		///<p>Time for transit in minutes</p>
		// @generated
		public int TransitTime
		{

			get
			{
				return transitTime;
			}

			set
			{
				SetField(ref transitTime, value, () => TransitTime);
			}

		}



	
	}
	

}



