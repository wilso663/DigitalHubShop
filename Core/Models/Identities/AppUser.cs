using Microsoft.AspNetCore.Identity;
using System.Net.Sockets;

namespace Core.Models.Identities
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}
