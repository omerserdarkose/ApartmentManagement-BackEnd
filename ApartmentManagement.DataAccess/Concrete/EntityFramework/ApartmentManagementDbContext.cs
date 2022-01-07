using System;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

/*Scaffold-DbContext "Server=DRMORAREES\SQLEXPRESS01;Database=ApartmentManagementDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Concrete/ -ContextDir ../ApartmentManagement.DataAccess/Concrete/EntityFramework/ -Context ApartmentManagementDbContext*/

#nullable disable

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public partial class ApartmentManagementDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DRMORAREES\SQLEXPRESS01;Database=ApartmentManagementDb;Trusted_Connection=True;");
            }
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserExpense> UserExpenses { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }

    }
}
