using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DB
{
    public class Role
    {
        public RoleId RoleId { get; set; }

        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
