namespace ChatApp.Application.DTOs
{
    public class DeleteMessageDTOs
    {
        public string? Id { get; set; }
        public MessageAppDTOs? MessageAppDTOs { get; set; }
        public string? DeleteUserId { get; set; }
    }
}
