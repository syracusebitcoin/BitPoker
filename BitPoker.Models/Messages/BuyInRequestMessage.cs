﻿using System;

namespace BitPoker.Models.Messages
{
    public class BuyInRequestMessage : BaseMessage
    {
        public Guid TableId { get; set; }

        public Int64 Amount { get; set; }

        /// <summary>
        /// Pub key required for multisig.  
        /// </summary>
        public Byte[] PubKey { get; set; }
    }
}
