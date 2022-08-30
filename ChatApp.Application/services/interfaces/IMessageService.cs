using ChatApp.Application.DTOs;
using ChatApp.DataAccess.Entities;

namespace ChatApp.Application.services.interfaces
{

    public interface IMessageService
    {
        IEnumerable<MessageAppDTOs> GetAll();
        IEnumerable<Message> GetReceivedMessages(string userId);
        Task<Message> AddMessageAsync(Message messageAppDTOs);
        void DeleteMessage(DeleteMessageDTOs deleteMessageDTOs);
    }
}
