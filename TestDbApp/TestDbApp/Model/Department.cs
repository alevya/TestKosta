using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDbApp.Model
{
    [Table("Department")]
    public class Department
    {
        private readonly HashSet<Employee> _employees;
        //private readonly ObservableCollection<Employee> _employees;
        public Department()
        {
            //var emps = new ObservableCollection<Employee>();
            //_employees = emps;
            //emps.CollectionChanged += (sender, e) =>
            //{
            //    if (e.NewItems != null)
            //    {
            //        foreach (Employee item in e.NewItems)
            //        {
            //            if (item.Department != this)
            //            {
            //                item.Department = this;
            //            }
            //        }
            //    }

            //    if (e.OldItems == null) return;

            //    foreach (Employee item in e.OldItems)
            //    {
            //        if (item.Department == this)
            //        {
            //            item.Department = null;
            //        }
            //    }

            //};

            _employees = new HashSet<Employee>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name:"ID")]
        public Guid DepartmentId { get; set; }
        public Guid? ParentDepartmentID { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Employee> Employees => _employees;

        public virtual Department Parent { get; set; }
        public virtual ICollection<Department> Children { get; set; }
    
    }
}
