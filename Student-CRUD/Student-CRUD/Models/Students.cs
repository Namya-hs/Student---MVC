using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Student_CRUD.Models
{
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth
        {
            get => _dateOfBirth;
            set => _dateOfBirth = value?.ToUniversalTime();
        }

        private DateTime? _dateOfBirth;

        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Address { get; set; }
    }
}
