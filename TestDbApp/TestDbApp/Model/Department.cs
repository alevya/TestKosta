using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDbApp.Model
{
    public class Department
    {
        public Department()
        {
            var emps = new ObservableCollection<Employee>();
            Employees = emps;
            emps.CollectionChanged += (sender, e) =>
            {
                if (e.NewItems != null)
                {
                    foreach (Employee item in e.NewItems)
                    {
                        if (item.Department != this)
                        {
                            item.Department = this;
                        }
                    }
                }

                if (e.OldItems == null) return;

                foreach (Employee item in e.OldItems)
                {
                    if (item.Department == this)
                    {
                        item.Department = null;
                    }
                }

            };
        }

        public Guid ID { get; set; }
        public Guid? ParentDepartmentID { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; }
    }
}
