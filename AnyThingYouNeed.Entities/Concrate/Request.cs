using AnyThingYouNeed.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.Entities.Concrate
{
    public class Request:IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RoomNumber { get; set; }
        public bool Hair { get; set; }
        public bool Skin { get; set; }
        public bool Teeth { get; set; }
        public bool PcpOther { get; set; }
        public string OtherPcpDetail { get; set; }
        public bool IstanbulTour { get; set; }
        public bool TraditionalProduct { get; set; }
        public bool TpOther { get; set; }
        public string TpOtherDetail { get; set; }
        public bool Taxi { get; set; }
        public bool VipCar { get; set; }
        public bool MobilePhone { get; set; }
        public bool LoptopCharger { get; set; }
        public string DetailsAndOthers { get; set; }
        public bool Status { get; set; }
        public DateTime SaveDate { get; set; } = DateTime.Now;
        public DateTime ConfirmDate { get; set; } = DateTime.Now;
    }
}
