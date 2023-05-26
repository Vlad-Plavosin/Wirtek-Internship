using Microsoft.AspNetCore.Components;

namespace WBizTrip.Client.Shared
{
    public partial class TableTemplate<TItem>
    {
        [Parameter]
        public RenderFragment TableHeader { get; set; }

        [Parameter]
        public RenderFragment<TItem> RowTemplate { get; set; }

        [Parameter]
        public IReadOnlyList<TItem> Items { get; set; }

    }
}
