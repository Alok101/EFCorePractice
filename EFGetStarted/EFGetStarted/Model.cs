using EFGetStarted.Practice;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
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
        public DbSet<OfficeLaptop> OfficeLaptop { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Blog_RS> Blog_Rs { get; set; }
        public DbSet<Post_RS> Post_Rs { get; set; }

        public DbSet<Blogger> Bloggers { get; set; }
        public DbSet<BloggerPost> BloggerPosts { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Blog_FK> Blog_FK { get; set; }
        public DbSet<Post_FK> Post_FK { get; set; }

        public DbSet<Blog_FK_AK> Blog_FK_AK { get; set; }
        public DbSet<Post_FK_AK> Post_FK_AK { get; set; }

        public DbSet<Blog_Ins> Blog_Ins { get; set; }
        public DbSet<RssBlog> RssBlogs { get; set; }
        public DbSet<BlogBase> BlogBase { get; set; }
        public DbSet<Blog_BackFielding> BackFieldings { get; set; }
        public DbSet<Rider> Rider { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
            //.UseLoggerFactory(GlobalInstance.MyLoggerFactory)
            .UseSqlServer(@"Data Source=DEL1-LHP-N67629;Database=Blogging;Trusted_Connection=True;",
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
            modelBuilder.Entity<Key>().HasKey(c => new { c.LicensePlate, c.State }).HasName("Key_PK_Composite");


            modelBuilder.Entity<Post_AK>()
            .HasOne(p => p.Blog)
            .WithMany(b => b.Posts)
            .HasForeignKey(p => p.BlogUrl)
            .HasPrincipalKey(b => b.Url);

            modelBuilder.Entity<Person>().Property(b => b.DisplayName).HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
            modelBuilder.Entity<Person>().Property(b => b.LastName).IsConcurrencyToken();
            modelBuilder.Entity<EmployeeSalaryNew>().Property(b => b.TotalSalary).HasComputedColumnSql("[BasicSalary]+[HRA]").IsConcurrencyToken();
            modelBuilder.Entity<EmployeeSalaryNew>().Property<DateTime>("LastUpdated");
            modelBuilder.Entity<Post_FK>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey("BloogerForeignKeyId").HasConstraintName("Foreign_Key_Constraint_Category");
            modelBuilder.Entity<Post_FK_AK>()
                .HasOne<Blog_FK_AK>().WithMany().HasForeignKey(f => f.BlogId).HasConstraintName("FK_AK_ForeignKey_Contraint");

            modelBuilder.Entity<RecordOfSale>()
                .HasOne(rs => rs.Car)
                .WithMany(c => c.SaleHistory)
                .HasForeignKey(fk => fk.CarLicensePlate)
                .HasPrincipalKey(pk => pk.LicensePlate);

            modelBuilder.Entity<Post_FK_AK_PK>().HasOne<Blog_FK_AK_PK>().WithMany().HasForeignKey("ShadowBlogId").IsRequired();

            //Index
            modelBuilder.Entity<Blog>().HasIndex(b => b.Url).IsUnique().HasFilter("[Url] IS NOT NULL").IncludeProperties(p => new
            {
                p.Title,
                p.PublishedOn
            });

            modelBuilder.Entity<Blog_Ins>()
        .HasDiscriminator<string>("blog_type")
        .HasValue<Blog_Ins>("blog_base")
        .HasValue<RssBlog>("blog_rss");

            modelBuilder.Entity<Blog_Shared>()
           .Property(b => b.Url)
           .HasColumnName("Url");

            modelBuilder.Entity<RssBlog>()
                .Property(b => b.Url)
                .HasColumnName("Url");

            modelBuilder.Entity<Blog_BackFielding>()
    .Property(b => b.Url)
    .HasField("_validatedUrl")
    .UsePropertyAccessMode(PropertyAccessMode.Field);
            modelBuilder
        .Entity<Rider>()
        .Property(e => e.Mount)
        .HasConversion(
            v => v.ToString(),
            v => (EquineBeast)Enum.Parse(typeof(EquineBeast), v));

            modelBuilder.Entity<DetailedOrder>(dob =>
            {
                dob.ToTable("Orders");
                dob.Property(o => o.Status).HasColumnName("Status");
            });

            modelBuilder.Entity<Order>(ob =>
            {
                ob.ToTable("Orders");
                ob.Property(o => o.Status).HasColumnName("Status");
                ob.HasOne(o => o.DetailedOrder).WithOne()
                    .HasForeignKey<DetailedOrder>(o => o.Id);
            });


        }
        public DbSet<Logger> Logging { get; set; }
    }

    public class Blog
    {
        private string _validatedUrl;
        public int BlogId { get; set; }
        public string Url { get; set; }
        public string GetUrl()
        {
            return _validatedUrl;
        }

        public void SetUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
            }

            _validatedUrl = url;
        }
        public string Title { get; set; }
        public string PublishedOn { get; set; }
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
        public int MessageId { get; set; }
        [Required]
        public string Messages { get; set; }
    }
    [Table("Server", Schema = "Facebook")]
    public class ServerConfiguration
    {
        [Key]
        public int ServerId { get; set; }
        [Required]
        public string ServerName { get; set; }
    }
    public class Blog_BackFielding
    {
        private string _validatedUrl;
        [Key]
        public int BlogId { get; set; }

        public string Url
        {
            get { return _validatedUrl; }
        }

        public void SetUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
            }

            _validatedUrl = url;
        }
    }
    public class Rider
    {
        public int Id { get; set; }
        public EquineBeast Mount { get; set; }
    }

    public enum EquineBeast
    {
        Donkey,
        Mule,
        Horse,
        Unicorn
    }
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus? Status { get; set; }
        public DetailedOrder DetailedOrder { get; set; }
    }
    public class DetailedOrder
    {
        public int Id { get; set; }
        public OrderStatus? Status { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public byte[] Version { get; set; }
    }
    public enum OrderStatus
    {
        Pending,
        Success,
        Waiting,
        Dispatched
    }
}
