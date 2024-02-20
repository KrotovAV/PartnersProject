using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataBaseLoginPassword.DB
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public byte[] Password { get; set; }

        public byte[] Salt { get; set; }

        public RoleId RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
