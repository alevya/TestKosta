using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDbApp.Model
{
    [Table("Empoyee")]
    public class Employee
    {
        private Department _department;

        public decimal ID { get; set; }
        public Guid DepartmentID { get; set; }

        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string DocSeries { get; set; }
        public string DocNumber { get; set; }
        public string Position { get; set; }

        public Department Department
        {
            get => _department;
            set
            {
                if (value != _department)
                {
                    Department originalDepartment = _department;
                    _department = value;

                    if (originalDepartment != null && originalDepartment.Employees.Contains(this))
                    {
                        originalDepartment.Employees.Remove(this);
                    }

                    // Add to new collection
                    if (value != null && !value.Employees.Contains(this))
                    {
                        value.Employees.Add(this);
                    }
                }
            }
        }
    }
}
