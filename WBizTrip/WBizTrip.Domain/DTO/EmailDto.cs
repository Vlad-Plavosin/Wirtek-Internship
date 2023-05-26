using WBizTrip.Domain.Enums;

namespace WBizTrip.Domain.DTO
{
    public class EmailDto
    {
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public UserRole Receivers { get; set; }
    }
}