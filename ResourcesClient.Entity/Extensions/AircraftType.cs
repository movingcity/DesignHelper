using com.unisys.rms.domain;
using System;
using ResourcesClient.Entity.Util;
using System.Text;

///<p>Reference Data entities</p>
namespace com.unisys.rms.domain.reference
{
    ///<p>Type of aircraft</p>
    public partial class AircraftType : RMSEntity
    {
        #region Non domain model methods for optimization at client

        public string Name
        {
            get
            {
                StringBuilder builder = new StringBuilder(description);
                builder.Append("(").Append(code).Append(")");
                return builder.ToString();
            }
        }

        #endregion
    }
}



