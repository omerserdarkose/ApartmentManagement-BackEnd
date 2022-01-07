using ApartmentManagement.Core.Entities;
using System;

namespace ApartmentManagement.Entities.Dtos.ExpenseType
{
    public class ExpenseTypeAddDto : IDto
    {
        public string Name { get; set; }
    }
}