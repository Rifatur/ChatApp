namespace ChatApp.DataAccess.Entities
{
    public class Message
    {
        public string? Id { get; set; }
        public string? Sender { get; set; }
        public string? Receiver { get; set; }
        public DateTime Created { get; set; }
        public string? MessageContent { get; set; }
        public bool IsDeletedSender { get; set; }

    }
}
