using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFGetStarted.Practice
{
    public class Blogger
    {
        public int BloggerId { get; set; }
        public string Url { get; set; }
        public List<BloggerPost> Posts { get; set; }
    }
    public class BloggerPost
    {
        public int BloggerPostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BloggerId { get; set; }
        public Blogger Blogger { get; set; }
        public int AuthorUserId { get; set; }
        public User Author { get; set; }

        public int ContributorUserId { get; set; }
        public User Contributor { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [InverseProperty("Author")]
        public List<BloggerPost> AuthoredPosts { get; set; }

        [InverseProperty("Contributor")]
        public List<BloggerPost> ContributedToPosts { get; set; }
    }

}
