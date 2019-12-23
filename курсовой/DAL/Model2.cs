namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model1")
        {
        }

        public virtual DbSet<EXPENSE> EXPENSEs { get; set; }
        public virtual DbSet<EXPENSE_GUIDE> EXPENSE_GUIDEs { get; set; }
        public virtual DbSet<INCOME> INCOMEs { get; set; }
        public virtual DbSet<INCOME_GUIDE> INCOME_GUIDEs { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<USER> USERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EXPENSE>()
                .Property(e => e.expense_size)
                .HasPrecision(15, 2);

            modelBuilder.Entity<EXPENSE_GUIDE>()
                .Property(e => e.expense_type)
                .IsUnicode(false);

            modelBuilder.Entity<EXPENSE_GUIDE>()
                .HasMany(e => e.EXPENSE)
                .WithOptional(e => e.EXPENSE_GUIDE)
                .HasForeignKey(e => e.expense_guide_FK);

            modelBuilder.Entity<INCOME>()
                .Property(e => e.income_size)
                .HasPrecision(15, 2);

            modelBuilder.Entity<INCOME_GUIDE>()
                .Property(e => e.income_type)
                .IsUnicode(false);

            modelBuilder.Entity<INCOME_GUIDE>()
                .HasMany(e => e.INCOME)
                .WithOptional(e => e.INCOME_GUIDE)
                .HasForeignKey(e => e.income_guide_FK);

            modelBuilder.Entity<USER>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.limit_size)
                .HasPrecision(15, 2);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.EXPENSE)
                .WithOptional(e => e.USER)
                .HasForeignKey(e => e.expense_user_FK);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.INCOME)
                .WithOptional(e => e.USER)
                .HasForeignKey(e => e.income_user_FK);
        }
    }
}
