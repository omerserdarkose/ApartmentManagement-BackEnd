using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Core.Entities
{
    public interface IUpdate
    {
        int? UuserId { get; set; }
        DateTime? Udate { get; set; }
    }
}
