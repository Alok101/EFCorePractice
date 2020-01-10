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
        public Blog_AK Blog { get; set; }
    }
}
