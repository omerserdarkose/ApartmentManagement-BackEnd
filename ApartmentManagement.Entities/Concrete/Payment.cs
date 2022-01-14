using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities;
using MongoDB.Bson;

namespace ApartmentManagement.Entities.Concrete
{
    public class Payment:IEntity
    {
        public ObjectId Id { get; set; }
        public int ApartmentId { get; set; }
        public int ExpenseId { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardCVC { get; set; }
        public string CardValDate { get; set; }
        public string Type { get; set; }
        public string ExpenseName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
