using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestDbApp.Common;

namespace TestDbApp.Model
{
    [Table("Empoyee")]
    public class Employee
    {
     
        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }
        [Required]
        public Guid DepartmentID { get; set; }

        [Required, StringLength(50)]
        public string SurName { get; set; }
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string Patronymic { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                var diff = new DifferenceDate(DateOfBirth, DateTime.Now);
                return diff.Years;
            }
        }

        [StringLength(4)]
        public string DocSeries { get; set; }

        [StringLength(6)]
        public string DocNumber { get; set; }

        [Required, StringLength(50)]
        public string Position { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

    }
}
