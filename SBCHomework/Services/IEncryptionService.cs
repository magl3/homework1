﻿using SBCHomework.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBCHomework.Services
{
    public interface IEncryptionService
    {
        void Encrypt(Message message, int key);

        Message Decrypt(Message message, int key);
    }
}
