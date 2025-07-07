
namespace YourApp.Models
{
    public class EditUserModel
    {
        public int Id { get; set; }
        public string Branch { get; set; }
        public string Counter { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string? NepaliName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string Contact { get; set; }
        public string? OtherContact { get; set; }
        public string? Email { get; set; }
        public string? PasswordOption { get; set; } // Keep this for logic if needed
        public bool Active { get; set; }
        public string? Remarks { get; set; }

        // Notice: No 'Password' property!
    }
}