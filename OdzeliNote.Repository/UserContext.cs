using System.Data.Entity;
using OdzeliNote.Repository.Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace OdzeliNote.Repository
{
    public class UserContext : DbContext
    {
        private const string SchemaName = "odzeliNote";

        public UserContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public UserContext(string _connectionString)
        : base(_connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaName);

            modelBuilder.Entity<Note>().HasKey(n => n.Id).ToTable("Note");
            modelBuilder.Entity<Note>().Property(n => n.Text).IsOptional();
            modelBuilder.Entity<Note>().Property(n => n.Created).IsOptional();
            modelBuilder.Entity<Note>().Property(n => n.Changed).IsOptional();
            modelBuilder.Entity<Note>().Property(n => n.Name).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Note>().HasRequired(n => n.User).WithMany().HasForeignKey(n => n.UserId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Note>().HasOptional(n => n.Category).WithMany().HasForeignKey(n => n.CategoryId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Note>().Property(n => n.Id).HasColumnName("NoteId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Category>().HasKey(c => c.Id).ToTable("Category");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(1000).IsRequired();
            modelBuilder.Entity<Category>().HasRequired(c => c.User).WithMany().HasForeignKey(c => c.UserId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Category>().HasOptional(c => c.Note).WithMany().HasForeignKey(c => c.NoteId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnName("CategoryId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Share>().HasKey(s => s.Id).ToTable("Share");
            modelBuilder.Entity<Share>().HasRequired(s => s.Note).WithMany().Map(n => n.MapKey("NoteId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<Share>().HasRequired(s => s.User).WithMany().Map(n => n.MapKey("UserId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<Share>().Property(s => s.Id).HasColumnName("ShareId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("UserId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>().Property(u => u.Name).HasMaxLength(1000).IsRequired();
        }

        public virtual DbSet<Note> Note { get; set; }

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Category> Category { get; set; }
    }
}
