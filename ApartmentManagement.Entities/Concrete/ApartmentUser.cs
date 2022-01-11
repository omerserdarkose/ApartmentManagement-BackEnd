using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Concrete
{
    public class ApartmentUser:IEntity
    {
        public int ApartmentId { get; set; }
        public int OwnerId { get; set; }
        public int? HirerId { get; set; }
        public bool IsActve { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
        public int? UuserId { get; set; }
        public DateTime? Udate { get; set; }
    }
}
