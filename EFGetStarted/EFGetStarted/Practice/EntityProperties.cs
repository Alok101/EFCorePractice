using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFGetStarted.Practice
{
    //Included and excluded properties
    public class EntityProperties
    {
        [Key]
        public int EntityId { get; set; }
        [Column("Entity_Url",TypeName ="varchar(200)")]
        [Required]
        public string Url { get; set; }

        [NotMapped]
        public DateTime LoadedFromDatabase { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Rating { get; set; }
    }
    public class CustomerWithOutNullableReferenceType
    {
        public int Id { get; set; }
        [Required]                               // Data annotations needed to configure as required
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }     // Data annotations needed to configure as required
        public string MiddleName { get; set; }   // Optional by convention
    }
    public class CustomerWithNullReferenceType
    {
        public int Id { get; set; }
        public string FirstName { get; set; }    // Required by convention
        public string LastName { get; set; }     // Required by convention
        public string? MiddleName { get; set; }  // Optional by convention

        public CustomerWithNullReferenceType(string firstName, string lastName, string? middleName = null)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
    }
}
