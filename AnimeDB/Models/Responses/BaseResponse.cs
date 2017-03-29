using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimeDB.Models.Responses
{
        /// <summary>
        /// The Base class for all our Response models. 
        /// If it is going out the door from our Api it must inherit form here.
        /// </summary>
        public abstract class BaseResponse
        {
            public bool IsSuccessful { get; set; }

            public string TransactionId { get; set; }

            protected BaseResponse()
            {
                this.TransactionId = Guid.NewGuid().ToString();
            }

            public bool Success { get; set; }
        }
    }