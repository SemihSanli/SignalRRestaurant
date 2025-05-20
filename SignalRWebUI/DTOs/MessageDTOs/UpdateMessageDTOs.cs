using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.DTOs.MessageDTOs
{
    public class UpdateMessageDTOs
    {
        public int MessageID { get; set; }
        public string MessageFullName { get; set; }
        public string MessageMail { get; set; }
        public string MessagePhoneNumber { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageSendDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}
