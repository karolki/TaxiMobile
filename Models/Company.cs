using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TaxiMobile.Model
{
    public class Company
    {
        public virtual int Com_ComId { get; set; }
        
        [IgnoreDataMember]
        public virtual ISet<Driver> DriverList { get; set; }
        [IgnoreDataMember]
        public virtual ISet<Taxi> TaxiList { get; set; }

        public virtual string Com_Name { get; set; }

        public virtual decimal AverageRating
        {
            get
            {
                if (DriverList.Count == 0) return 0;
                var count = 0;
                var sum = 0M;
                foreach (var driver in DriverList)
                {
                    sum += driver.AverageRating;
                    count += driver.AverageRating == 0 ? 0 : 1;
                }
                return sum / count;
            }
        }

        public Company()
        {
            DriverList = new HashSet<Driver>();

            TaxiList = new HashSet<Taxi>();
        }
    }
}
