using System.ComponentModel.DataAnnotations;
using WBizTrip.Domain.Model;

namespace WBizTrip.Domain.DTO
{
    public class TeamLeaderDto
    {
        public int Id { get; set; }
        public string Team { get; set; } = String.Empty;
        public User? User { get; set; }
        public string Name { get; set; } = String.Empty;
        //[EmailAddress(ErrorMessage = "E-mail address is not valid!")]
        public string Email { get; set; } = String.Empty;
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z]).{8,}$",
        ErrorMessage = "Password must be at least 8 characters long and contain one number, one lower case and one upper case letter")]
        public string Password { get; set; } = String.Empty;
        public int UserId { get; set; }
    }
}

