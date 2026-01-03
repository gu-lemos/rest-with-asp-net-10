using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET10.Model
{
    [Table("person")]
    public class Person
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private set; }

        [Required]
        [Column("first_name", TypeName = "varchar(80)")]
        [MaxLength(80)]
        public string FirstName { get; private set; } = string.Empty;

        [Required]
        [Column("last_name", TypeName = "varchar(80)")]
        [MaxLength(80)]
        public string LastName { get; private set; } = string.Empty;

        [Required]
        [Column("address", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Address { get; private set; } = string.Empty;

        [Required]
        [Column("gender", TypeName = "varchar(6)")]
        [MaxLength(6)]
        public string Gender { get; private set; } = string.Empty;

        public void Update(string firstName, string lastName, string address, string gender) 
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Gender = gender; 
        }
    }
}
