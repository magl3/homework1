﻿using SBCHomework.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBCHomework.Models
{
    public class MessageViewModel
    {
        public ParticipantViewModel Sender { get; set; }

        public ParticipantViewModel Recipient { get; set; }

        public Message Message { get; set; }
    }
}
