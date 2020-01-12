using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFGetStarted.Practice
{
    public class Inheritance
    {

    }
    public class Blog_Ins
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }
    }

    public class RssBlog : Blog_Ins
    {
        public string RssUrl { get; set; }
    }
    public abstract class BlogBase
    {
        [Key]
        public int BlogId { get; set; }
    }

    public class Blog_Shared : BlogBase
    {
        public string Url { get; set; }
    }

    public class RssBlog_Shared : BlogBase
    {
        public string Url { get; set; }
    }
}
