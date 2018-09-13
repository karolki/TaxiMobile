using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiMobile.Model
{
    public class Car
    {
        public virtual int Car_CarId { get; set; }

        public virtual string Car_Model { get; set; }

        public virtual string Car_Mark { get; set; }
    }
}
