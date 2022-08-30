using ChatApp.Application.DTOs;

namespace ChatApp.Application.services.interfaces
{

    public interface IMessageService
    {
        IEnumerable<MessageAppDTOs> GetAll();
        IEnumerable<MessageAppDTOs> GetReceivedMessages(string userId);
        Task<MessageAppDTOs> AddMessageAsync(MessageAppDTOs messageAppDTOs);
        void DeleteMessage(DeleteMessageDTOs deleteMessageDTOs);
    }
}
