namespace DBModel.ET
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Advertise> Advertises { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Calender> Calenders { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Former> Formers { get; set; }
        public virtual DbSet<GrantPermission> GrantPermissions { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupCalendar> GroupCalendars { get; set; }
        public virtual DbSet<GroupsSide> GroupsSides { get; set; }
        public virtual DbSet<GroupUser> GroupUsers { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsTag> NewsTags { get; set; }
        public virtual DbSet<NoteCalender> NoteCalenders { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Side> Sides { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<StatsInfo> StatsInfoes { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Support> Supports { get; set; }
        public virtual DbSet<SupportGroup> SupportGroups { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.MetaTite)
                .IsUnicode(true);

            modelBuilder.Entity<About>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Advertise>()
                .Property(e => e.Target)
                .IsUnicode(false);

            modelBuilder.Entity<Advertise>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Advertise>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Advertise>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Calender>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Calender>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Calender>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaTite)
                .IsUnicode(true);

            modelBuilder.Entity<Category>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.SortName)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Former>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Former>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Former>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Former>()
                .Property(e => e.VerificationCode)
                .IsUnicode(false);

            modelBuilder.Entity<Former>()
                .Property(e => e.IPLogin)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<GroupCalendar>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<GroupsSide>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<GroupsSide>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<GroupsSide>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Target)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MenuType>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MenuType>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.MetaTite)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<NewsTag>()
                .Property(e => e.TagID)
                .IsUnicode(false);

            modelBuilder.Entity<NoteCalender>()
                .Property(e => e.Detail)
                .IsUnicode(false);

            modelBuilder.Entity<NoteCalender>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<NoteCalender>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.BusinessID)
                .IsUnicode(false);

            modelBuilder.Entity<Side>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Side>()
                .Property(e => e.Target)
                .IsUnicode(false);

            modelBuilder.Entity<Side>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Side>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Side>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<StatsInfo>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<StatsInfo>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<StatsInfo>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Support>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Support>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.LanguageID)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.TagID)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.VerificationCode)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.IPLogin)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);
        }
    }
}
