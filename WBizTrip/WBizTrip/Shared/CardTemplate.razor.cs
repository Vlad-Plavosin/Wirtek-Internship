using Microsoft.AspNetCore.Components;
using WBizTrip.Domain.DTO;

namespace WBizTrip.Client.Shared
{
    public partial class CardTemplate
    {
        [Parameter]
        public RenderFragment cardHead { get; set; }
        [Parameter]
        public RenderFragment cardBody { get; set; }
    }
}