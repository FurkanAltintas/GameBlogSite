using GameBlogSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameBlogSite.Models
{
    public class WriterChatMessage
    {
        public IEnumerable<WriterChat> WriterChat { get; set; }
        public IEnumerable<WriterChatReply> WriterChatReply { get; set; }
    }
}