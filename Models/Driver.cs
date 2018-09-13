using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TaxiMobile.Model
{
    [DataContractAttribute]
    public class Driver
    {
        public virtual string Personality { get { return $"{Drv_Name} {Drv_Surname}"; } }
        [DataMemberAttribute]
        public virtual int Drv_DrvId { get; set; }
        [DataMemberAttribute]
        public virtual string Drv_Name { get; set; }
        [DataMemberAttribute]
        public virtual string Drv_Surname { get; set; }
        [DataMemberAttribute]
        public virtual string Drv_Identity { get; set; }
        [DataMemberAttribute]
        public virtual string Drv_Password { get; set; }
        [DataMemberAttribute]
        public virtual decimal Drv_Latitude { get; set; }
        [DataMemberAttribute]
        public virtual decimal Drv_Longitude { get; set; }
        [IgnoreDataMember]
        public virtual DateTime Drv_Timing { get; set; }
        [DataMemberAttribute]
        public virtual string Drv_Phone { get; set; }
        
        public virtual Company Company { get; set; }

        public virtual decimal Distance {get;set;}

        [IgnoreDataMember]
        public virtual ISet<Opinion> OpinionList { get; set; }
        [DataMemberAttribute]
        public virtual ObservableCollection<Opinion> Opinions {
            get
            {
                return new ObservableCollection<Opinion>(OpinionList);
            }
            set
            {
                OpinionList = new HashSet<Opinion>(value);
            }
        }

        public virtual decimal AverageRating
        {
            get
            {
                if (Opinions.Count == 0) return 0;

                var sum = 0M;
                foreach(var opinion in Opinions)
                {
                    sum += opinion.Opi_Rating;
                }
                return sum / Opinions.Count;
            }
        }

        public Driver()
        {
            OpinionList = new HashSet<Opinion>();
        }

    }
}
