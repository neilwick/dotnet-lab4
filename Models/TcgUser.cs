using Microsoft.AspNetCore.Identity;

namespace Lab4.Models
{
    public class TcgUser : IdentityUser {
        public string favourite { get; set; } = "forest";
    }
}