
using com.unisys.rms.domain;
using com.unisys.rms.domain.resource;
using com.unisys.rms.domain.system;





///<p>Carousel resource related entities</p>
// @generated
namespace com.unisys.rms.domain.resource.carousel
{

	
	///<p>Defines colors for groups of stand. </p><p>Such colours are used to display the background colour of unallocated flight carousel tasks in the Carousel Gantt in RMS based on the stands on which the same flight’s stand tasks are allocated in the airport </p>
	// @wasgenerated
	public partial class UnallocCarouselStand : RMSEntity
	{


		// @generated
		private Stand stand;



		// @generated
		private Color color;



		///<p>The stand whose Flight Task is allocated in Stand module</p>
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


	

		///<p>The background color to be used for the unallocated Carousel Task</p>
		// @generated
		public Color Color
		{

			get
			{
				return color;
			}

			set
			{
				SetField(ref color, value, () => Color);
			}

		}



	
	}
	

}



