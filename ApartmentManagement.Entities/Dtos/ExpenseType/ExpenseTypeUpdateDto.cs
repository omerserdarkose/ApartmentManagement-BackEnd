using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Entities.Dtos.ExpenseType
{
    public class ExpenseTypeUpdateDto:IDto
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }
}
