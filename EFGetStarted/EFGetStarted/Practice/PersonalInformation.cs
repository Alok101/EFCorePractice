using System;
using System.Collections.Generic;
using System.Text;

namespace EFGetStarted.Practice
{
    public class PersonalInformation
    {
        public int PersonalInformationId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
}
