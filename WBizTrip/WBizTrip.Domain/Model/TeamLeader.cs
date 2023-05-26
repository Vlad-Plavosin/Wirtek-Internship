using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WBizTrip.Domain.Model
{
    public class TeamLeader
    {
        public int Id { get; set; }
        public string Team { get; set; } = String.Empty;
        [JsonIgnore]
        [IgnoreDataMember]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
