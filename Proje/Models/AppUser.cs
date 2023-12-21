using Microsoft.AspNetCore.Identity;

namespace Proje.Models
{
    public class AppUser: IdentityUser{

        public string? FullName {get; set;} 
    }
    
}