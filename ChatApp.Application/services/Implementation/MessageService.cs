using ChatApp.Application.DTOs;
using ChatApp.Application.services.interfaces;
using ChatApp.DataAccess;
using ChatApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Application.services.Implementation
{

    public class MessageService : IMessageService
    {
        protected readonly ApplicationDbContext _context;
        public MessageService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Message> AddMessageAsync(Message messageAppDTOs)
        {
            var result = await _context.AddAsync(messageAppDTOs);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteMessage(DeleteMessageDTOs deleteMessageDTOs)
        {
            var result = await _context.Messages.FirstOrDefaultAsync(m => m.Id == deleteMessageDTOs.Id);
            if (result != null)
            {
                _context.Messages.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<MessageAppDTOs> GetAll()
        {
            try
            {
                var messages = _context.Messages.ToList();
                return (IEnumerable<MessageAppDTOs>)messages;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Message> GetReceivedMessages(string userId)
        {
            var messages = _context.Messages.Where(x => x.Receiver == userId).ToList();
            return messages;
        }


    }
}
