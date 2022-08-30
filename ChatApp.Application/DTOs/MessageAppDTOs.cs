namespace ChatApp.Application.DTOs
{
    public class MessageAppDTOs
    {
        public string? Id { get; set; }
        public string? Sender { get; set; }
        public string? Receiver { get; set; }
        public DateTime Created { get; set; }
        public string? Text { get; set; }
        public bool IsDeletedSender { get; set; }
    }
}
