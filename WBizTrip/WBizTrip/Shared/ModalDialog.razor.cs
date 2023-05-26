namespace WBizTrip.Client.Shared
{
    public class ModalDialog
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public EventCallback<bool> OnClose { get; set; }
    }
}
