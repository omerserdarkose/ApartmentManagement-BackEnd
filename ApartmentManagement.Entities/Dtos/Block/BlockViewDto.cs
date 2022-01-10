using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;

namespace ApartmentManagement.Entities.Dtos.Block
{
    public class BlockViewDto:IDto
    {
        public short Id { get; set; }
        public string Letter { get; set; }
    }
}
