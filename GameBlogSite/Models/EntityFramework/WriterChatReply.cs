//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameBlogSite.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class WriterChatReply
    {
        public int Id { get; set; }
        public Nullable<int> WriterChatId { get; set; }
        public Nullable<int> WriterId { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual Writer Writer { get; set; }
        public virtual WriterChat WriterChat { get; set; }
    }
}
