using System.ComponentModel.DataAnnotations;

namespace WBizTrip.Domain.DTO
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = String.Empty;
        [Required(ErrorMessage = "Phone number is required")]
        [Phone (ErrorMessage = "Phone number is not valid")]
        public string PhoneNumber { get; set; } = String.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Budget must be higher than 0!")]
        public float AnnualBudget { get; set; }
        public TeamLeaderDto? TeamLeader { get; set; }
        public int? TeamLeaderId { get; set; }
    }
}
