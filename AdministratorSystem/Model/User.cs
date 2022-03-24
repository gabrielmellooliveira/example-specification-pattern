using System.Collections.Generic;

namespace AdministratorSystem.Model
{
    public class User
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Profile Profile { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
