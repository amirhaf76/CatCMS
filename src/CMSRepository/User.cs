using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSRepository
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserStatus Status { get; set; }

        public ICollection<Host> Hosts { get; set; } = new List<Host>();
    }

    public class Host
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public User Creator { get; set; }
    }
}
