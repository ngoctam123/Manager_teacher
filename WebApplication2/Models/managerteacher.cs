using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication2.Models
{
    public partial class managerteacher : DbContext
    {
        public managerteacher()
            : base("name=managerteacher")
        {
        }

        public virtual DbSet<CalendarWorking> CalendarWorkings { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<GroupUser> GroupUsers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<ReportMonth> ReportMonths { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Science> Sciences { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TypeCalendar> TypeCalendars { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Class)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.UserGroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<GroupUser>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<GroupUser>()
                .Property(e => e.CodeRole)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Science>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Science)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Science>()
                .HasMany(e => e.Teachers)
                .WithRequired(e => e.Science)
                .HasForeignKey(e => e.SicenceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeCalendar>()
                .HasMany(e => e.CalendarWorkings)
                .WithRequired(e => e.TypeCalendar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Work>()
                .HasMany(e => e.CalendarWorkings)
                .WithRequired(e => e.Work)
                .WillCascadeOnDelete(false);
        }
    }
}
