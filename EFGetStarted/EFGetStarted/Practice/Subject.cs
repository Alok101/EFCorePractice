using System;
using System.Collections.Generic;
using System.Text;

namespace EFGetStarted.Practice
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public Teacher Teacher { get; set; }
    }
}
