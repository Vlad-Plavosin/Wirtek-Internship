using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WBizTrip.Domain.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        [MaxLength(10)]
        public string PhoneNumber { get; set; } = String.Empty;
        [Range(0, int.MaxValue)]
        public float AnnualBudget { get; set; }
        public TeamLeader? TeamLeader { get; set; }
        [ForeignKey("TeamLeaderId")]
        public int? TeamLeaderId { get; set; }
        public List<Trip> Trips { get; set; }
    }
}
