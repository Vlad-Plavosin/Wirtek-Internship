using WBizTrip.Domain.Enums;

namespace WBizTrip.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public UserRole Role { get; set; }
        public TeamLeader? TeamLeader { get; set; }
    }
}
