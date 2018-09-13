using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiMobile.Model
{
    public class Taxi
    {
        public virtual int Tax_TaxId { get; set; }

        /// <summary>
        /// Tax_ComId
        /// </summary>
        public virtual Company Company { get; set; }
            
        /// <summary>
        /// Tax_DrvId
        /// </summary>
        public virtual Driver Driver {get;set;}

        /// <summary>
        /// Tax_CarId
        /// </summary>
        public virtual Car Car { get; set; }

        public virtual List<Opinion> OpinionList { get; set; }

        public virtual decimal Tax_Latitude { get; set; }

        public virtual decimal Tax_Longitude { get; set; }

        public Taxi()
        {
            OpinionList = new List<Opinion>();
            
        }

        //public virtual LatLng LatLng {
        //    get {
        //        return new LatLng((double)Tax_Latitude, (double)Tax_Longitude);
        //    }
        //    set {
        //        LatLng = value;
        //        Tax_Latitude = (decimal)LatLng.Latitude;
        //        Tax_Longitude = (decimal)LatLng.Longitude;
        //    }
        //}

    }
}
