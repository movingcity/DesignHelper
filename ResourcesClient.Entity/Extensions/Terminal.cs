using com.unisys.rms.domain;
using System;
using ResourcesClient.Entity.Util;
using System.Text;

///<p>Reference Data entities</p>
namespace com.unisys.rms.domain.reference
{
    ///<p>Terminal in the airport</p>
    public partial class Terminal : RMSEntity
    {
        private bool highlighted;

        /// <summary>
        /// Keep highlight status for reference data objects
        /// </summary>
        public bool Highlighted
        {
            get
            {
                return highlighted;
            }
            set
            {
                SetField(ref highlighted, value, () => Highlighted);
            }
        }
    }
}



