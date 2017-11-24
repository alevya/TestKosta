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
            //var emps = new ObservableCollection<Employee>();
            //Employees = emps;
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

        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Guid? ParentDepartmentID { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Employee> Employees
        {
            get
            {

                return _employees;
            }
        }
    }
}
