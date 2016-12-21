using System.Collections.ObjectModel;
using com.unisys.rms.domain.resource;

///<p>Allocation template related entities</p>
namespace com.unisys.rms.domain.template
{
    ///<p>Template flight members for Carousel module</p>
    public partial class CarouselFlightMember : FlightMember
    {
        public ObservableCollection<Carousel> Carousels
        {
            get
            {
                return carousels;
            }
            set
            {
                SetField(ref carousels, value, () => Carousels);
            }
        }
    }
}



