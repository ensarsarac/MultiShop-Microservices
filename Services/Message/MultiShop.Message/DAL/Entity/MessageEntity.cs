namespace MultiShop.Message.DAL.Entity
{
    public class MessageEntity
    {
        public int MessageEntityId { get; set; }
        public string SenderId { get; set; }
        public string ReceiveId { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public bool IsRead { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
