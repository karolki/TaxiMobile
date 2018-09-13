using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TaxiMobile.Model
{
    public class Opinion
    {
        public virtual int Opi_OpiId { get; set; }

        public virtual string Opi_Person { get; set; }

        public virtual DateTime Opi_Date { get; set; }

        public virtual string Opi_Description { get; set; }

        public virtual decimal Opi_Rating { get; set; }
        [IgnoreDataMember]
        public virtual Driver Driver { get; set; }
        [IgnoreDataMember]
        public virtual Taxi Taxi { get; set; }
    }
}
