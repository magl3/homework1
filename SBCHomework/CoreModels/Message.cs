using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBCHomework.CoreModels
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public string Data { get; set; }

        public DateTime DateUpdated { get; set; }

        public int ChatId { get; set; }
    }
}
