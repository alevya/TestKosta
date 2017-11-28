using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDbApp.Model
{
    [Table("Department")]
    public class Department
    {
        private readonly HashSet<Employee> _employees;
        public Department()
        {
            _employees = new HashSet<Employee>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name:"ID")]
        public Guid DepartmentId { get; set; }
        public Guid? ParentDepartmentID { get; set; }

        [StringLength(10)]
        public string Code { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }

        public ICollection<Employee> Employees => _employees;

        public virtual Department Parent { get; set; }
        public virtual ICollection<Department> Children { get; set; }

    }
}
