using AutoMapper;
using MultiShop.Message.DAL.Entity;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<MessageEntity, CreateMessageDto>().ReverseMap();
            CreateMap<MessageEntity, UpdateMessageDto>().ReverseMap();
            CreateMap<MessageEntity, ResultInboxMessageDto>().ReverseMap();
            CreateMap<MessageEntity, ResultSendboxMessageDto>().ReverseMap();
            CreateMap<MessageEntity, ResultMessageDto>().ReverseMap();
        }
    }
}
