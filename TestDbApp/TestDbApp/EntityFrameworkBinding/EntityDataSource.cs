using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDbApp.EntityFrameworkBinding
{
    public partial class EntityDataSource : Component
    {
        public EntityDataSource()
        {
            InitializeComponent();
        }

        public EntityDataSource(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
