using ApartmentManagement.Core.Entities;
using System;

namespace ApartmentManagement.Entities
{
    public class ExpenseTypeAddDto : IDto, IInsert
    {
        public string Name { get; set; }
        public int IuserId { get; set; }
        public DateTime Idate { get; set; }
    }
}