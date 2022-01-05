using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Core.Entities
{
    public interface IEntity
    {
        int IuserId { get; set; }
        DateTime Idate { get; set; }
        int? UuserId { get; set; }
        DateTime? Udate { get; set; }
    }
}
