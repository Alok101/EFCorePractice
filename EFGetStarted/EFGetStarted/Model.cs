using EFGetStarted.Practice;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFGetStarted
{
    public class BloggingContext : DbContext
    {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<TransactionRow> Transactions { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ServerConfiguration> ServerConfigurations { get; set; }
        public DbSet<EntityProperties> EntityProperties { get; set; }
        public DbSet<CustomerWithOutNullableReferenceType> CustomerWithOutNullableRefeneceTypes { get; set; }
        public DbSet<CustomerWithNullReferenceType> CustomerWithNullReferenceType { get; set; }
        public DbSet<Blog_AK> Blogs_AK { get; set; }
        public DbSet<Post_AK> Posts_AK { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<EmployeeSalaryNew> EmployeeSalarys { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
            //.UseLoggerFactory(GlobalInstance.MyLoggerFactory)
            .UseSqlServer(@"Data Source=DESKTOP-4QP84H1;Database=Blogging;Trusted_Connection=True;",
                options => options.EnableRetryOnFailure());
        //public BloggingContext(DbContextOptions<BloggingContext> options):base(options)
        //{
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().Property(b => b.Url).IsRequired();
            modelBuilder.Entity<AuditEntry>();
            modelBuilder.Ignore<BlogMetadata>();//Excluding types from the model
            modelBuilder.Entity<Message>().ToTable("MessageSystems");
            //modelBuilder.HasDefaultSchema("blogging");
            modelBuilder.Entity<Key>().HasKey(c => new { c.LicensePlate,c.State }).HasName("Key_PK_Composite");


            modelBuilder.Entity<Post_AK>()
            .HasOne(p => p.Blog)
            .WithMany(b => b.Posts)
            .HasForeignKey(p => p.BlogUrl)
            .HasPrincipalKey(b => b.Url);

            modelBuilder.Entity<Person>().Property(b => b.DisplayName).HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
            modelBuilder.Entity<Person>().Property(b => b.LastName).IsConcurrencyToken();
            modelBuilder.Entity<EmployeeSalaryNew>().Property(b => b.TotalSalary).HasComputedColumnSql("[BasicSalary]+[HRA]").IsConcurrencyToken();
        }
        public DbSet<Logger> Logging { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Inserted { get; set; }
        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
    public class TransactionRow
    {
        [Key]
        public int TransId { get; set; }
        public Guid GUID { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
    public class Logger
    {
        [Key]
        public int LogId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
    public class AuditEntry
    {
        public int AuditEntryId { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
    }
    //Excluding types from the model
    [NotMapped]
    public class BlogMetadata
    {
        public DateTime LoadedFromDatabase { get; set; }
    }
    [Table("MessageSystem")]
    public class Message
    {
        [Key]
        public int MessageId { get; set;}
        [Required]
        public string Messages { get; set; }
    }
    [Table("Server",Schema ="Facebook")]
    public class ServerConfiguration
    {
        [Key]
        public int ServerId { get; set; }
        [Required]
        public string ServerName { get; set; }
    }

}
