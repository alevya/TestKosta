using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDbApp.Model
{
    [Table("Empoyee")]
    public class Employee
    {
        public Employee() { }

        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }
        [Required]
        public Guid DepartmentID { get; set; }

        [Required, MaxLength(50)]
        public string SurName { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }

        [MaxLength(4)]
        public string DocSeries { get; set; }
        [MaxLength(6)]
        public string DocNumber { get; set; }
        [Required, MaxLength(50)]
        public string Position { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        [NotMapped]
        public string DepartmentName
        {
            get => Department.Name;
            set { }
        }

        //public Department Department
        //{
        //    get => _department;
        //    set
        //    {
        //        if (value != _department)
        //        {
        //            Department originalDepartment = _department;
        //            _department = value;

        //            if (originalDepartment != null && originalDepartment.Employees.Contains(this))
        //            {
        //                originalDepartment.Employees.Remove(this);
        //            }

        //            // Add to new collection
        //            if (value != null && !value.Employees.Contains(this))
        //            {
        //                value.Employees.Add(this);
        //            }
        //        }
        //    }
        //}
    }
}
