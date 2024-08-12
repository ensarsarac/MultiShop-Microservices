using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Concrete;
using MultiShop.Message.DAL.Entity;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class MessageService : IMessageService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public MessageService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var values = _mapper.Map<MessageEntity>(createMessageDto);

            await _context.Messages.AddAsync(values);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var values = await _context.Messages.FirstOrDefaultAsync(x => x.MessageEntityId == id);

            _context.Messages.Remove(values);

            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var values = await _context.Messages.ToListAsync();

            var mapped = _mapper.Map<List<ResultMessageDto>>(values);

            return mapped;
        }

        public async Task<GetByIdMessageDto> GetByIdMessage(int id)
        {
            var value = await _context.Messages.FirstOrDefaultAsync(x => x.MessageEntityId == id);

            var mapped = _mapper.Map<GetByIdMessageDto>(value);

            return mapped;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessage(string id)
        {
            var values = await _context.Messages.Where(x=>x.ReceiveId == id).ToListAsync();

            var mapped = _mapper.Map<List<ResultInboxMessageDto>>(values);

            return mapped;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessage(string id)
        {
            var values = await _context.Messages.Where(x => x.SenderId == id).ToListAsync();

            var mapped = _mapper.Map<List<ResultSendboxMessageDto>>(values);

            return mapped;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            throw new NotImplementedException();
        }
    }
}
