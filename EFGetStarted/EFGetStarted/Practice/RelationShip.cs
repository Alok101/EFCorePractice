using System;
using System.Collections.Generic;
using System.Text;

namespace EFGetStarted.Practice
{
    public class RelationShip
    {

    }
    public class Teacher
    {
        public int TeacherId { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public List<Subject> Subjects { get; set; }

    }
    public class Student
    {
        public int StudentId { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public Courses Courses { get; set; }
        public Section Section { get; set; }
    }
    public class Blog_RS
    {
        public int Blog_RSId { get; set; }
        public string URL { get; set; }
        public List<Post_RS> Posts { get; set; }
    }
    public class Post_RS
    {
        public int Post_RSId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Blog_RS Blog { get; set; }
    }
    public class Blog_RS1
    {
        public int Blog_RSId { get; set; }
        public string URL { get; set; }
    }
    public class Post_RS1
    {
        public int Post_RSId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Blog_RS1 Blog_RS1 { get; set; }
    }
}
