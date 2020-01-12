using System;
using System.Collections.Generic;
using System.Text;

namespace EFGetStarted.Practice
{
    public class Section
    {
        public int SectionId { get; set; }
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }
        public Teacher Incharge { get; set; }
    }
}
