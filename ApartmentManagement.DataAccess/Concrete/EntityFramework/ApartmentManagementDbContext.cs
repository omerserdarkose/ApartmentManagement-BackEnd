using System;
using ApartmentManagement.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

/*Scaffold-DbContext "Server=DRMORAREES\SQLEXPRESS01;Database=ApartmentManagementDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Concrete/ -ContextDir ../ApartmentManagement.DataAccess/Concrete/EntityFramework/ -Context ApartmentManagementDbContext*/

#nullable disable

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public partial class ApartmentManagementDbContext : DbContext
    {
        public ApartmentManagementDbContext()
        {
        }

        public ApartmentManagementDbContext(DbContextOptions<ApartmentManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Block> Blocks { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserExpense> UserExpenses { get; set; }
        public virtual DbSet<UserMessage> UserMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DRMORAREES\\SQLEXPRESS01;Database=ApartmentManagementDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.HasIndex(e => e.Status, "IX_Apartments_Status")
                    .HasFillFactor((byte)90);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IuserId).HasColumnName("IUserId");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.UuserId).HasColumnName("UUserdId");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.BlockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Apartments_Blocks");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Apartments_Users");
            });

            modelBuilder.Entity<Block>(entity =>
            {
                entity.HasIndex(e => e.Letter, "UK_ApartmentBlocks_BlockSign")
                    .IsUnique();

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IuserId).HasColumnName("IUserId");

                entity.Property(e => e.Letter)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.UuserId).HasColumnName("UUserId");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasIndex(e => e.LicensePlate, "UK_Cars_LicensePlate")
                    .IsUnique();

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IuserId).HasColumnName("IUserId");

                entity.Property(e => e.LicensePlate)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.UuserId).HasColumnName("UUserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cars_Users");
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.HasIndex(e => e.IsActive, "IX_Claims_IsActive")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Name, "UK_Claims_Name")
                    .IsUnique();

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IuserId).HasColumnName("IUserId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.UuserId).HasColumnName("UUserdId");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasIndex(e => e.Date, "IX_Expenses_Date")
                    .HasFillFactor((byte)90);

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IuserId).HasColumnName("IUserId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.UuserId).HasColumnName("UUserId");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expenses_ExpenseTypes");
            });

            modelBuilder.Entity<ExpenseType>(entity =>
            {
                entity.HasIndex(e => e.Name, "UK_ExpenseTypes_Name")
                    .IsUnique();

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IuserId).HasColumnName("IUserId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.UuserId).HasColumnName("UUserId");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasIndex(e => e.Idate, "IX_Messages_IDate")
                    .HasFillFactor((byte)90);

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IuserId).HasColumnName("IUserId");

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.UuserId).HasColumnName("UUserId");

                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Message");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.IsActive, "IX_Users_LastName_IsActive")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.Email, "UK_Users_Email")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IuserId).HasColumnName("IUserId");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.UuserId).HasColumnName("UUserId");
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.ClaimId }, "UK_UserClaims_UserId_ClaimId")
                    .IsUnique();

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IuserId).HasColumnName("IUserId");

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.UuserId).HasColumnName("UUserdId");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.ClaimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserClaims_Claims");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserClaims_Users");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasIndex(e => e.IsActive, "IX_UserDetails_IsActive");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdentityNo)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IuserId).HasColumnName("IUserId");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.UuserId).HasColumnName("UUserId");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UserDetail)
                    .HasForeignKey<UserDetail>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDetails_Users");
            });

            modelBuilder.Entity<UserExpense>(entity =>
            {
                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IuserId).HasColumnName("IUserId");

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.UuserId).HasColumnName("UUserId");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.UserExpenses)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserExpenses_Apartments");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.UserExpenses)
                    .HasForeignKey(d => d.ExpenseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserExpenses_Expenses");
            });

            modelBuilder.Entity<UserMessage>(entity =>
            {
                entity.HasIndex(e => e.Idate, "IX_UserMessages_IDate")
                    .HasFillFactor((byte)90);

                entity.Property(e => e.Idate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActiveFuser).HasColumnName("IsActiveFUser");

                entity.Property(e => e.IsNew)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IuserId).HasColumnName("IUserId");

                entity.Property(e => e.Udate)
                    .HasColumnType("datetime")
                    .HasColumnName("UDate");

                entity.Property(e => e.UuserId).HasColumnName("UUserId");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.UserMessageFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMessages_Users");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.UserMessages)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMessages_Messages");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.UserMessageToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMessages_Users1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
