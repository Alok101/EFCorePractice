using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFGetStarted.Practice
{
    public class Key
    {
        [Key]
        public string LicensePlate { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }
        public string State { get; set; }
    }
    public class Blog_AK
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post_AK> Posts { get; set; }
    }

    public class Post_AK
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string BlogUrl { get; set; }
        public int BlogId { get; set; }
       public Blog_AK Blog { get; set; }
        
    }
    public class Blog_FK
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post_FK> Posts { get; set; }
    }

    public class Post_FK
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Blog_FK Blog { get; set; }
    }
    public class Blog_FK_AK
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }

    }

    public class Post_FK_AK
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
    #region Principle Key Implementation

    public class Car
    {
        public int CarId { get; set; }
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public List<RecordOfSale> SaleHistory { get; set; }
    }

    public class RecordOfSale
    {
        public int RecordOfSaleId { get; set; }
        public DateTime DateSold { get; set; }
        public decimal Price { get; set; }

        public string CarLicensePlate { get; set; }
        public Car Car { get; set; }
    }
    #endregion
    #region Shadow_Property_Checker
    public class Blog_FK_AK_PK
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }
    }

    public class Post_FK_AK_PK
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
    #endregion
}
