using System.ComponentModel;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BiluthyrningApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public bool Blacklist { get; set; }
        public bool IsAdmin { get; set; }
        [DisplayName("Förnamn")]
        public string FirstName { get; set; } = "";
        [DisplayName("Efternamn")]
        public string LastName { get; set; } = "";
        [DisplayName("Mailadress")]
        public string Email { get; set; } = "";
        [DisplayName("Telefonnummer")]
        public string PhoneNumber { get; set; } = "";
    }
}
